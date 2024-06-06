using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.OrderRepository;
using JewelryProduction.Repository.UserRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Customer;
using JewelryProduction.Service.Response.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.CustomerImpl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService()
        {
            if (orderRepository == null)
            {
                orderRepository = new OrderRepository();
            }
        }

        public GetOrderReponse Create(CreateOrderRequest createOrderRequest)
        {
            Order order = OrderConverter.toEntityForCreate(createOrderRequest);

            Order newOrder = orderRepository.Create(order);

            return OrderConverter.toDto(newOrder);
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
