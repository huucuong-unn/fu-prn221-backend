using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Response.Counter;
using System;

namespace JewelryProduction.Service.Service.Counter
{
    public interface ICounterService
    {
        GetCounterResponse Create(GetCounterRequest createCounterRequest);

        bool ChangeStatus(Guid id);

        GetCounterResponse GetById(Guid id);

        PagingModel<GetCounterResponse> GetAll(FilterModel filterModel);

        List<GetCounterResponse> GetCountersWithoutPaging();

        int TotalCounter();

        bool Update(Guid id, GetCounterRequest updateCounterRequest);
    }
}