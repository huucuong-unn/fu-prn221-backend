using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CounterRepository;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.OrderRepository;
using JewelryProduction.Repository.ProductsRepository;
using JewelryProduction.Repository.UserCounterRepository;
using JewelryProduction.Repository.UserRepository;
using JewelryProduction.Repository.WarrantyRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Response.Order;
using Microsoft.IdentityModel.Tokens;

namespace JewelryProduction.Service.CustomerImpl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        private readonly IOrderItemRepository orderItemRepository;

        private readonly ICustomerRepository customerRepository;

        private readonly IWarrantyRepository warrantyRepository;

        private readonly IProductRepository productRepository;

        private readonly IUserCounterRepository userCounterRepository;

        private readonly ICounterRepository counterRepository;

        public OrderService()
        {
            if (orderRepository == null)
            {
                orderRepository = new OrderRepository();
            }

            if (orderItemRepository == null)
            {
                orderItemRepository = new OrderItemRepository();
            } 

            if (customerRepository == null)
            {
                customerRepository = new CustomerRepository();
            }

            if (warrantyRepository == null) 
            {
                warrantyRepository = new WarrantyRepository();
            }

            if (productRepository == null)
            {
                productRepository = new ProductRepository();
            }

            if (userCounterRepository == null)
            {
                userCounterRepository = new UserCounterRepository();
            }

            if (counterRepository == null)
            {
                counterRepository = new CounterRepository();
            }
        }

        public Dictionary<string, object> Create(CreateOrderRequest createOrderRequest)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();

            Customer customer = customerRepository.GetByPhone(createOrderRequest.CustomerPhone);

            if (customer == null)
            {
                customer = customerRepository.Create(new Customer ()
                {
                    Name = createOrderRequest.CustomerName,
                    Phone = createOrderRequest.CustomerPhone,
                    Description = "Customer",
                    Point = 0,
                    Status = "ACTIVE",
                    CreateDate = DateTime.Now,
                    CreateBy = createOrderRequest.CreateBy,
                });
            } 

            createOrderRequest.CustomerId = customer.Id;
            Order order = OrderConverter.toEntityForCreate(createOrderRequest);

            Order newOrder = orderRepository.Create(order);

            var counterId = userCounterRepository.GetCounterIdByStaffId(Guid.Parse(createOrderRequest.CreateBy));
            if (!createOrderRequest.ListProductCode.IsNullOrEmpty())
            {
                foreach (string productCode in createOrderRequest.ListProductCode)
                {
                    var warranty = warrantyRepository.Create(new Warranty()
                    {
                        StartDate = DateOnly.FromDateTime(DateTime.Now),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3)),//expired default 3 months,
                        Description = "Expired after 3 months",
                        Status = "ACTIVE",
                        CreateBy = createOrderRequest.CreateBy,
                        CreateDate = DateTime.Now

                    });

                    var product = productRepository.GetProductByProductCode(productCode);

                    var orderItem = orderItemRepository.Create(new OrderItem
                    {
                        ProductId = product.Id,
                        WarrantyId = warranty.Id,
                        OrderId = newOrder.Id,
                        TotalAmount = product.Price,
                        Quantity = 1,
                        UnitPrice = product.Price,
                        CreateBy = createOrderRequest.CreateBy,
                        CreatedDate = DateTime.Now,
                        Status = "ACTIVE"
                    });

                    order.OrderItems.Add(orderItem);    
                    newOrder.TotalAmount += orderItem.TotalAmount;
                    product.Status = "INACTIVE";
                    var updatedProduct = product;
                    productRepository.Update(updatedProduct.Id, updatedProduct);
                }
            }

            newOrder.CounterId = counterId;
            orderRepository.Update(newOrder.Id, newOrder);

            var counterForUpdate = counterRepository.GetCounterById(counterId);
            counterForUpdate.Income = (decimal)(counterForUpdate.Income + newOrder.TotalAmount);
            counterRepository.Update(counterForUpdate.Id, counterForUpdate);

            response.Add("order", newOrder);
            return response;
        }

        public bool Delete(Guid id)
        {
            return orderRepository.Delete(id);
        }

        public PagingModel<GetOrderReponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetOrderReponse> result = new PagingModel<GetOrderReponse>();
            result.Page = filterModel.PageIndex;
            List<Order> orders = orderRepository.GetOrders(filterModel);
            foreach (Order order in orders)
            {
                List<OrderItem> items = new List<OrderItem>();
                items = orderItemRepository.GetOrderItemsByOrderId(order.Id);
                order.OrderItems = items;

            }

            List<GetOrderReponse> getOrderResponses = orders.Select(orders =>
            {
                return OrderConverter.toDto(orders);
            }).ToList();

            result.ListResult = getOrderResponses;
            result.Size = filterModel.PageSize;
            return result;
        }

        public GetOrderReponse GetById(Guid id)
        {
            Order order = orderRepository.GetById(id);
            return OrderConverter.toDto(order);
        }

        public int TotalItem()
        {
            return orderRepository.TotalItem();
        }

        public bool Update(Guid id, UpdateOrderRequest updateOrderRequest)
        {
            Order order = OrderConverter.toEntityForUpdate(updateOrderRequest);
            return orderRepository.Update(id, order);
        }
    }
}
