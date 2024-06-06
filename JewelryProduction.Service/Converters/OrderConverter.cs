using JewelryProduction.Service.Response.User;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Order;
using JewelryProduction.Service.Request.Customer;

namespace JewelryProduction.Service.Converters
{
    public class OrderConverter
    {
        public static GetOrderReponse toDto(Order order)
        {
            GetOrderReponse getOrdersReponse = new GetOrderReponse();
            getOrdersReponse.Id = order.Id;
            getOrdersReponse.CustomerId = (Guid)order.CustomerId;
            getOrdersReponse.PromotionId = (Guid)order.PromotionId;
            getOrdersReponse.TotalAmount = (decimal)order.TotalAmount;
            getOrdersReponse.OrderType = order.OrderType;
            getOrdersReponse.CreatedDate = (DateTime)order.CreatedDate;
            getOrdersReponse.UpdatedDate = (DateTime)order.UpdatedDate;
            getOrdersReponse.CreateBy = order.CreateBy;
            getOrdersReponse.UpdateBy = order.UpdateBy;
            getOrdersReponse.Status = order.Status;
            return getOrdersReponse;
        }

        public static Order toEntityForCreate(CreateOrderRequest createOrderRequest)
        {
            Order order = new Order();
            order.CustomerId = createOrderRequest.CustomerId;
            order.PromotionId = createOrderRequest.PromotionId; 
            order.TotalAmount = createOrderRequest.TotalAmount;
            order.OrderType = createOrderRequest.OrderType;
            order.CreatedDate = (DateTime)createOrderRequest.CreatedDate;
            order.UpdatedDate = (DateTime)createOrderRequest.UpdatedDate;
            order.CreateBy = createOrderRequest.CreateBy;
            order.UpdateBy = createOrderRequest.UpdateBy;
            return order;
        }

        public static Order toEntityForUpdate(UpdateOrderRequest updateOrderRequest)
        {
            Order order = new Order();
            order.CustomerId = updateOrderRequest.CustomerId;
            order.PromotionId = updateOrderRequest.PromotionId;
            order.TotalAmount = updateOrderRequest.TotalAmount;
            order.OrderType = updateOrderRequest.OrderType;
            order.CreatedDate = (DateTime)updateOrderRequest.CreatedDate;
            order.UpdatedDate = (DateTime)updateOrderRequest.UpdatedDate;
            order.CreateBy = updateOrderRequest.CreateBy;
            order.UpdateBy = updateOrderRequest.UpdateBy;
            order.Status = updateOrderRequest.Status;
            return order;
        }
    }
}
