using JewelryProduction.BusinessObject.Models;
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
            getOrdersReponse.CustomerId = order.CustomerId;
            getOrdersReponse.PromotionId = order.PromotionId;
            getOrdersReponse.TotalAmount = order.TotalAmount;
            getOrdersReponse.OrderType = order.OrderType;
            getOrdersReponse.CreatedDate = order.CreatedDate;
            getOrdersReponse.UpdatedDate = order.UpdatedDate;
            getOrdersReponse.CreateBy = order.CreateBy;
            getOrdersReponse.UpdateBy = order.UpdateBy;
            getOrdersReponse.Status = order.Status;
            getOrdersReponse.CounterId = order.CounterId;
            getOrdersReponse.OrderItems = (List<OrderItem>?)order.OrderItems;
            getOrdersReponse.Customer = order.Customer;

            return getOrdersReponse;
        }

        public static GetOrderReponse toResponse(Order order, List<OrderItem> list)
        {
            GetOrderReponse getOrdersReponse = new GetOrderReponse();
            getOrdersReponse.Id = order.Id;
            getOrdersReponse.CustomerId = order.CustomerId;
            getOrdersReponse.PromotionId = order.PromotionId;
            getOrdersReponse.TotalAmount = order.TotalAmount;
            getOrdersReponse.OrderType = order.OrderType;
            getOrdersReponse.CreatedDate =  order.CreatedDate;
            getOrdersReponse.UpdatedDate =  order.UpdatedDate;
            getOrdersReponse.CreateBy = order.CreateBy;
            getOrdersReponse.UpdateBy = order.UpdateBy;
            getOrdersReponse.Status = order.Status;
            foreach (var item in list)
            {
                getOrdersReponse.OrderItems.Add(item);
            };
            getOrdersReponse.CounterId = order.CounterId;
            getOrdersReponse.Customer = order.Customer;
            return getOrdersReponse;
        }

        public static Order toEntityForCreate(CreateOrderRequest createOrderRequest)
        {
            Order order = new Order();
            order.CustomerId = createOrderRequest.CustomerId;
            order.PromotionId = createOrderRequest.PromotionId; 
            order.TotalAmount = createOrderRequest.TotalAmount;
            order.OrderType = createOrderRequest.OrderType;
            order.CreatedDate = createOrderRequest.CreatedDate;
            order.UpdatedDate = createOrderRequest.UpdatedDate;
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
            order.CreatedDate = updateOrderRequest.CreatedDate;
            order.UpdatedDate = updateOrderRequest.UpdatedDate;
            order.CreateBy = updateOrderRequest.CreateBy;
            order.UpdateBy = updateOrderRequest.UpdateBy;
            order.Status = updateOrderRequest.Status;
            return order;
        }
    }
}
