using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Response.Customer;
using JewelryProduction.Service.CustomerImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class CustomerController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet(ApiEndPointConstant.Customer.GET_CUSTOMER)]
        public PagingModel<GetCustomerResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return customerService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.Customer.GET_CUSTOMER_BY_ID + "{id}")]
        public GetCustomerResponse GetById(Guid id)
        {
            return customerService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.Customer.CREATE_CUSTOMER)]
        public GetCustomerResponse Create(CreateCustomerRequest createCustomerRequest)
        {
            return customerService.Create(createCustomerRequest);
        }

        [HttpPut(ApiEndPointConstant.Customer.UPDATE_CUSTOMER + "{id}")]
        public bool Update(Guid id, UpdateCustomerRequest updateCustomerRequest)
        {
            return customerService.Update(id, updateCustomerRequest);
        }

        [HttpDelete(ApiEndPointConstant.Customer.CHANGE_STATUS_CUSTOMER + "{id}")]
        public bool Delete(Guid id)
        {
            return customerService.ChangeStatus(id);
        }
    }
}
