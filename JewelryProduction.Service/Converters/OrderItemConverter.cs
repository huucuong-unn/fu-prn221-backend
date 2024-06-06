using JewelryProduction.Service.Response.User;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Counter;

namespace JewelryProduction.Service.Converters
{
    public class OrderItemConverter
    {
        public static GetOrderItemResponse toDto(OrderItem orderitem)
        {
            GetOrderItemResponse getOrderItemResponse = new GetOrderItemResponse();
            getOrderItemResponse.Id = orderitem.Id;
            getOrderItemResponse.OrderId = (Guid)orderitem.OrderId;
            getOrderItemResponse.ProductId = (Guid)orderitem.ProductId;
            getOrderItemResponse.WarrantyId = (Guid)orderitem.WarrantyId;
            getOrderItemResponse.TotalAmount = (decimal)orderitem.TotalAmount;
            getOrderItemResponse.Quantity = (int)orderitem.Quantity;
            getOrderItemResponse.CreatedDate = (DateTime)orderitem.CreatedDate;
            getOrderItemResponse.UpdatedDate = (DateTime)orderitem.UpdatedDate;
            getOrderItemResponse.CreateBy = orderitem.CreateBy;
            getOrderItemResponse.UpdateBy = orderitem.UpdateBy;
            getOrderItemResponse.Status = orderitem.Status;
            return getOrderItemResponse;
        }

        public static OrderItem toEntityForCreate(BaseOrderItemRequest baseOrderItemRequest)
        {
            OrderItem orderitem = new OrderItem();
            orderitem.OrderId = baseOrderItemRequest.OrderId;
            orderitem.ProductId = baseOrderItemRequest.ProductId;
            orderitem.WarrantyId = baseOrderItemRequest.WarrantyId;
            orderitem.TotalAmount = baseOrderItemRequest.TotalAmount;
            orderitem.Quantity = baseOrderItemRequest.Quantity;
            orderitem.UnitPrice = baseOrderItemRequest.UnitPrice;
            orderitem.CreatedDate = DateTime.Now;
            orderitem.UpdatedDate = DateTime.Now;
            orderitem.CreateBy = baseOrderItemRequest.CreateBy;
                orderitem.UpdateBy = baseOrderItemRequest.UpdateBy;
                orderitem.Status = "ACTIVE";
            return orderitem;
        }

        public static OrderItem toEntityForUpdate(BaseOrderItemRequest updateOrderItemRequest)
        {
            OrderItem orderitem = new OrderItem();
            
           // orderitem.Status = updateOrderItemRequest.Status;
          
            return orderitem;
        }
    }
}
