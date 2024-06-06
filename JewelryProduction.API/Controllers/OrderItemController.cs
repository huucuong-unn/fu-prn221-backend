using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.CustomerImpl;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.User;
using JewelryProduction.Service.Service.Account;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class OrderItemController
    {
        private readonly IOrderItemService _orderitemService;

        public OrderItemController(IOrderItemService orderitemService)
        {
            _orderitemService = orderitemService;
        }

        [HttpGet(ApiEndPointConstant.OrderItem.GET_ORDERITEM)]
        public PagingModel<GetOrderItemResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _orderitemService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.OrderItem.GET_ORDERITEM_BY_ID+ "{id}")]
        public GetOrderItemResponse GetById(Guid id)
        {
            return _orderitemService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.OrderItem.CREATE_ORDERITEM)]
        public GetOrderItemResponse Create(BaseOrderItemRequest createOrderItemRequest)
        {
            return _orderitemService.Create(createOrderItemRequest);
        }

        [HttpPut(ApiEndPointConstant.OrderItem.UPDATE_ORDERITEM + "{id}")]
        public bool Update(Guid id, BaseOrderItemRequest updateOrderItemRequest)
        {
            return _orderitemService.Update(id, updateOrderItemRequest);
        }

        [HttpDelete(ApiEndPointConstant.OrderItem.CHANGE_STATUS_ORDERITEM + "{id}")]
        public bool ChangeStatus(Guid id)
        {
            return _orderitemService.ChangeStatus(id);
        }
    }
}
