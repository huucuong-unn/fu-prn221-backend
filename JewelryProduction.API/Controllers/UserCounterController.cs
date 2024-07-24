using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.UserCounter;
using JewelryProduction.Service.Response.UserCounter;
using JewelryProduction.Service.Service.UserCounter;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class UserCounterController : ControllerBase
    {
        private readonly IUserCounterService _userCounterService;

        public UserCounterController(IUserCounterService userCounterService)
        {
            _userCounterService = userCounterService;
        }

        [HttpGet(ApiEndPointConstant.UserCounter.GET_USER_COUNTER)]
        public PagingModel<GetUserCounterResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _userCounterService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.UserCounter.GET_USER_COUNTER_BY_ID + "{staffId}/{counterId}")]
        public GetUserCounterResponse GetById(Guid staffId, Guid counterId)
        {
            return _userCounterService.GetById(staffId, counterId);
        }
        
        [HttpGet(ApiEndPointConstant.UserCounter.GET_USER_COUNTER_BY_COUNTER_ID + "{counterId}")]
        public GetUserCounterResponse GetByCounterId( Guid counterId)
        {
            return _userCounterService.GetByCounterId( counterId);
        }

        [HttpPost(ApiEndPointConstant.UserCounter.CREATE_USER_COUNTER)]
        public GetUserCounterResponse Create(GetUserCounterRequest request)
        {
            return _userCounterService.Create(request);
        }

        [HttpPut(ApiEndPointConstant.UserCounter.UPDATE_USER_COUNTER + "{staffId}/{counterId}")]
        public bool Update(Guid staffId, Guid counterId, GetUserCounterRequest request)
        {
            return _userCounterService.Update(staffId, counterId, request);
        }
        
        

        [HttpPut(ApiEndPointConstant.UserCounter.CHANGE_STATUS_USER_COUNTER + "{staffId}/{counterId}")]
        public bool ChangeStatus(Guid staffId, Guid counterId)
        {
            return _userCounterService.ChangeStatus(staffId, counterId);
        }
    }
}
