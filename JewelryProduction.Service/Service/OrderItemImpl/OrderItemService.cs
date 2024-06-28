using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.UserRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.CustomerImpl
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository orderitemRepository;

        public OrderItemService()
        {
            if (orderitemRepository == null)
            {
                orderitemRepository = new OrderItemRepository();
            }
        }

        public GetOrderItemResponse Create(BaseOrderItemRequest baseOrderItemRequest)
        {
            OrderItem orderitem = OrderItemConverter.toEntityForCreate(baseOrderItemRequest);

            OrderItem newOrderItem = orderitemRepository.Create(orderitem);

            return OrderItemConverter.toDto(newOrderItem);
        }

        public bool ChangeStatus(Guid id)
        {
            return orderitemRepository.ChangeStatus(id);
        }

        public PagingModel<GetOrderItemResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetOrderItemResponse> result = new PagingModel<GetOrderItemResponse>();
            result.Page = filterModel.PageIndex;
            List<OrderItem> orderitems = orderitemRepository.GetOrderItems(filterModel);
            List<GetOrderItemResponse> getOrderItemResponses = orderitems.Select(orderitem =>
            {
                return OrderItemConverter.toDto(orderitem);
            }).ToList();

            result.ListResult = getOrderItemResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalItem()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public GetOrderItemResponse GetById(Guid id)
        {
            OrderItem orderitem = orderitemRepository.GetOrderItemById(id);
            return OrderItemConverter.toDto(orderitem);
        }

        public int TotalItem()
        {
            return orderitemRepository.TotalItem();
        }

        public bool Update(Guid id, BaseOrderItemRequest baseOrderItemRequest)
        {
            OrderItem orderitem = OrderItemConverter.toEntityForUpdate(baseOrderItemRequest);
            return orderitemRepository.Update(id, orderitem);
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return orderitemRepository.GetAllOrderItems();
        }
    }
}
