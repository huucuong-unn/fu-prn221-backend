using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Service.Counter;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;

        public CounterController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet(ApiEndPointConstant.Counter.GET_COUNTER)]
        public PagingModel<GetCounterResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _counterService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.Counter.GET_COUNTER_BY_ID + "{id}")]
        public GetCounterResponse GetById(Guid id)
        {
            return _counterService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.Counter.CREATE_COUNTER)]
        public GetCounterResponse Create(GetCounterRequest createCounterRequest)
        {
            return _counterService.Create(createCounterRequest);
        }

        [HttpPut(ApiEndPointConstant.Counter.UPDATE_COUNTER + "{id}")]
        public bool Update(Guid id, GetCounterRequest updateCounterRequest)
        {
            return _counterService.Update(id, updateCounterRequest);
        }

        [HttpDelete(ApiEndPointConstant.Counter.CHANGE_STATUS_COUNTER + "{id}")]
        public bool ChangeStatus(Guid id)
        {
            return _counterService.ChangeStatus(id);
        }
    }
}