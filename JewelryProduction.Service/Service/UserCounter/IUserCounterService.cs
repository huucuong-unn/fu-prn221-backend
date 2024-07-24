using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.Service.Request.UserCounter;
using JewelryProduction.Service.Response.UserCounter;
using System;
using System.Collections.Generic;
using JewelryProduction.BusinessObject.Paginate;

namespace JewelryProduction.Service.Service.UserCounter
{
    public interface IUserCounterService
    {
        GetUserCounterResponse Create(GetUserCounterRequest request);
        bool ChangeStatus(Guid staffId, Guid counterId);
        GetUserCounterResponse GetById(Guid staffId, Guid counterId);
        
        List<GetUserCounterResponse> GetByCounterId( Guid counterId);
        PagingModel<GetUserCounterResponse> GetAll(FilterModel filterModel);
        int TotalUserCounter();
        bool Update(Guid staffId, Guid counterId, GetUserCounterRequest request);
    }
}