using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Stone;
using JewelryProduction.Service.Response.Stone;
using System;

namespace JewelryProduction.Service.Service.Stone
{
    public interface IStoneService
    {
        GetStoneResponse Create(GetStoneRequest createStoneRequest);

        bool ChangeStatus(Guid id);

        GetStoneResponse GetById(Guid id);

        PagingModel<GetStoneResponse> GetAll(FilterModel filterModel);

        int TotalStone();

        bool Update(Guid id, GetStoneRequest updateStoneRequest);
    }
}