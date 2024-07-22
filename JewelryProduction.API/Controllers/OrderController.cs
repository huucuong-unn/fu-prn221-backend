using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.CustomerImpl;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Response.Order;
using JewelryProduction.Service.Response.ProductType;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{

    [ApiController]
    public class OrderController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet(ApiEndPointConstant.Order.GET_ORDER)]
        public PagingModel<GetOrderReponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return orderService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.Order.GET_ORDER_BY_ID + "{id}")]
        public GetOrderReponse GetById(Guid id)
        {
            return orderService.GetById(id);
        }

        [HttpGet(ApiEndPointConstant.Order.STATISTICAL_ORDER_SALES_PRODUCT)]
        public OrderDashboardResponse StatisticalOrderAndSalesAndProduct()
        {
            return orderService.StatisticalOrderAndSalesAndProduct();
        }

        [HttpGet(ApiEndPointConstant.Order.ORDER_DASHBOARD_FOR_BAR_CHART)]
        public List<OrderDashboardBarChartResponse> GetMonthlyOrderCount()
        {
            return orderService.GetMonthlyOrderCount();
        }

        [HttpGet(ApiEndPointConstant.Order.ORDER_DASHBOARD_FOR_LINE_CHART)]
        public Dictionary<string, decimal> OrderDashboardForLineChart()
        {
            return orderService.GetMonthlyRevenue();
        }

        [HttpGet(ApiEndPointConstant.Order.ORDER_TOP_5_CUSTOMER)]
        public List<Top5CustomerResponse> GetTop5Customers()
        {
            return orderService.GetTop5Customers();
        }

        [HttpGet(ApiEndPointConstant.Order.ORDER_DASHBOARD_FOR_PIE_CHART)]
        public List<GetProductTypeWithTotalOrder> GetProductTypeWithTotalOrder()
        {
            return orderService.GetProductTypeWithTotalOrder();
        }

        [HttpPost(ApiEndPointConstant.Order.CREATE_ORDER)]
        public Dictionary<string, object> Create(CreateOrderRequest createOrderRequest)
        {
            return orderService.Create(createOrderRequest);
        }

        [HttpPut(ApiEndPointConstant.Order.UPDATE_ORDER + "{id}")]
        public bool Update(Guid id, UpdateOrderRequest updateOrderRequest)
        {
            return orderService.Update(id, updateOrderRequest);
        }

        [HttpDelete(ApiEndPointConstant.Order.DELETE_ORDER + "{id}")]
        public bool Delete(Guid id)
        {
            return orderService.Delete(id);
        }

        [HttpGet(ApiEndPointConstant.Order.GET_ORDER_SEARCH)]
        public PagingModel<GetOrderReponse> SearchOrders(int page, int size, string? orderCode, DateTime? startDate, DateTime? endDate)
        {
            return orderService.SearchOrders(page, size, orderCode, startDate, endDate);
        }


    }


}
