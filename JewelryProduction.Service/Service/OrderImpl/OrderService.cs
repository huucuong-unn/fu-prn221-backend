﻿using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.DAO;
using JewelryProduction.Repository.CounterRepository;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.OrderRepository;
using JewelryProduction.Repository.ProductsRepository;
using JewelryProduction.Repository.ProductTypeRepository;
using JewelryProduction.Repository.UserCounterRepository;
using JewelryProduction.Repository.UserRepository;
using JewelryProduction.Repository.WarrantyRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Response.Order;
using JewelryProduction.Service.Response.ProductType;
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

        private readonly IProductTypeRepository productTypeRepository;

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

            if (productTypeRepository == null)
            {
                productTypeRepository = new ProductTypeRepository();    
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
            createOrderRequest.CreatedDate = DateTime.Now;
            createOrderRequest.UpdatedDate = DateTime.Now;

            Order order = OrderConverter.toEntityForCreate(createOrderRequest);
/*            order.Customer = customerRepository.GetById((Guid)order.CustomerId);
*/
            Order newOrder = orderRepository.Create(order);
            var counterId = userCounterRepository.GetCounterIdByStaffId(Guid.Parse(createOrderRequest.CreateBy));

            if (newOrder.OrderType.Equals("CustomerBuy"))
            {
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
                        product.Status = "SALED";
                        var updatedProduct = product;
                        productRepository.Update(updatedProduct.Id, updatedProduct);
                        productRepository.UpdateStatus(updatedProduct.Id, updatedProduct.Status);
                    }
                }

                newOrder.CounterId = counterId;
                orderRepository.Update(newOrder.Id, newOrder);
                customer.Point += (int?)(newOrder.TotalAmount / 100);
                var updatedCustomer = customer;
                customerRepository.Update(updatedCustomer.Id, updatedCustomer);

                var counterForUpdate = counterRepository.GetCounterById(counterId);
                counterForUpdate.Income = (decimal)(counterForUpdate.Income + newOrder.TotalAmount);
                counterRepository.Update(counterForUpdate.Id, counterForUpdate);
            } else if (newOrder.OrderType.Equals("StoreBuy"))
            {

                if (!createOrderRequest.ListProductCode.IsNullOrEmpty())
                {
                    foreach (string productCode in createOrderRequest.ListProductCode)
                    {
                        var warranty = warrantyRepository.Create(new Warranty()
                        {
                            StartDate = DateOnly.FromDateTime(DateTime.Now),
                            EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3)),//expired default 3 months,
                            Description = "Expired after 3 months",
                            Status = "BUYBACK",
                            CreateBy = createOrderRequest.CreateBy,
                            CreateDate = DateTime.Now

                        });

                        var reCalProduct = productRepository.ReCalProduct(productCode);

                        var orderItem = orderItemRepository.Create(new OrderItem
                        {
                            ProductId = reCalProduct.Id,
                            WarrantyId = warranty.Id,
                            OrderId = newOrder.Id,
                            TotalAmount = reCalProduct.Price,
                            Quantity = 1,
                            UnitPrice = reCalProduct.Price,
                            CreateBy = createOrderRequest.CreateBy,
                            CreatedDate = DateTime.Now,
                            Status = "ACTIVE"
                        });

                        order.OrderItems.Add(orderItem);
                        newOrder.TotalAmount += orderItem.TotalAmount;
                        reCalProduct.Status = "BUYBACK";
                        var updatedProduct = reCalProduct;
                        productRepository.Update(updatedProduct.Id, updatedProduct);
                        productRepository.UpdateStatus(updatedProduct.Id, updatedProduct.Status);
                    }
                    newOrder.CounterId = counterId;
                    orderRepository.Update(newOrder.Id, newOrder);
                }
            }
            

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
                foreach (var item in items)
                {
                    var appendProduct = productRepository.GetProductById((Guid)item.ProductId);
                    var productTypeId = appendProduct.ProductTypeId;
                    if(!productTypeId.Equals(Guid.Empty))
                    {
                        var productType = productTypeRepository.GetProductTypeById(productTypeId);
                        if (productType != null)
                        {
                            appendProduct.ProductType = productType;
                        }
                    }
                   

                    item.Product = appendProduct;
                }
                order.OrderItems = items;

                order.Customer = customerRepository.GetById((Guid)order.CustomerId);

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
            List<OrderItem> items = new List<OrderItem>();
            items = orderItemRepository.GetOrderItemsByOrderId(order.Id);
            foreach (var item in items)
            {
                var appendProduct = productRepository.GetProductById((Guid)item.ProductId);
                var productTypeId = appendProduct.ProductTypeId;
                if (!productTypeId.Equals(Guid.Empty))
                {
                    var productType = productTypeRepository.GetProductTypeById(productTypeId);
                    if (productType != null)
                    {
                        appendProduct.ProductType = productType;
                    }
                }


                item.Product = appendProduct;
            }
            order.OrderItems = items;

            order.Customer = customerRepository.GetById((Guid)order.CustomerId);
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

        public OrderDashboardResponse StatisticalOrderAndSalesAndProduct()
        {
            OrderDashboardResponse orderDashboardResponse = new OrderDashboardResponse();

            orderDashboardResponse.NumberOfOrders = orderRepository.TotalItem();
            orderDashboardResponse.Sales = orderRepository.GetTotalRevenue();
            orderDashboardResponse.NumberOfProduct = productRepository.TotalProducts();

            return orderDashboardResponse;
        }

        public Dictionary<string, decimal> GetMonthlyRevenue()
        {
            return orderRepository.GetMonthlyRevenue();
        }

        public List<OrderDashboardBarChartResponse> GetMonthlyOrderCount()
        {
            List<OrderDashboardBarChartResponse> orderDashboardBarChartResponses = new List<OrderDashboardBarChartResponse>();
            var totalOrderByMonth = orderRepository.GetMonthlyOrderCount();

            foreach (var item in totalOrderByMonth)
            {
                OrderDashboardBarChartResponse order = new OrderDashboardBarChartResponse();
                order.TotalOrder = item.Value;

                order.Month = item.Key;

                orderDashboardBarChartResponses.Add(order);
            }

            return orderDashboardBarChartResponses;
        }

        public PagingModel<GetOrderReponse> SearchOrders(int page, int size, string? orderCode, DateTime? startDate, DateTime? endDate)
        {
            PagingModel<GetOrderReponse> result = new PagingModel<GetOrderReponse>();
            result.Page = page;

            List<Order> orders = orderRepository.SearchOrders(page, size, orderCode, startDate, endDate);

            foreach (Order order in orders)
            {
                List<OrderItem> items = new List<OrderItem>();
                items = orderItemRepository.GetOrderItemsByOrderId(order.Id);
                foreach (var item in items)
                {
                    var appendProduct = productRepository.GetProductById((Guid)item.ProductId);
                    var productTypeId = appendProduct.ProductTypeId;
                    if (!productTypeId.Equals(Guid.Empty))
                    {
                        var productType = productTypeRepository.GetProductTypeById(productTypeId);
                        if (productType != null)
                        {
                            appendProduct.ProductType = productType;
                        }
                    }
                    item.Product = appendProduct;
                }
                order.OrderItems = items;
                order.Customer = customerRepository.GetById((Guid)order.CustomerId);
            }

            List<GetOrderReponse> getOrderResponses = orders.Select(order => OrderConverter.toDto(order)).ToList();

            result.ListResult = getOrderResponses;
            result.Size = size;
            var concu = orderRepository.TotalItem();
            var concac = ((double)orderRepository.TotalItem() / size);
            result.TotalPages = (int)Math.Ceiling((double)orderRepository.TotalItem() / size);
            return result;
        }

        public List<Top5CustomerResponse> GetTop5Customers()
        {
            var top5Customers = customerRepository.GetTop5CustomersWithMostOrders();

            
            return top5Customers.Select(c => new Top5CustomerResponse
            {
                Name = c.Name,
                PhoneNumber = c.Phone,
                TotalOrder = orderRepository.GetOrdersByCustomerId(c.Id).Count(o => o.Status == "ACTIVE")
            }).OrderByDescending(g => g.TotalOrder).ToList();
        }

        public List<GetProductTypeWithTotalOrder> GetProductTypeWithTotalOrder()
        {
            var productTypes = productTypeRepository.GetAllProductTypes();
            var orderItems = orderItemRepository.GetAllOrderItems();

            var result = productTypes.Select(pt => new GetProductTypeWithTotalOrder
            {
                ProductTypeName = pt.Name,
                TotalOrder = orderItems
                .Where(oi => oi.Product.ProductTypeId == pt.Id)
                .Sum(oi => (int) oi.Quantity)
            }).ToList();

            return result;
        }

        private Product ReCalProduct(Product product)
        {


            return null;
        }

    }

}
