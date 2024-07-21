using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.ProductStone;
using JewelryProduction.Service.Response.ProductStone;

namespace JewelryProduction.Service.Service.ProductStoneImpl
{
    public interface IProductStoneService
    {
        GetProductStoneResponse Create(GetProductStoneRequest createProductStoneRequest);

        bool Delete(Guid productId, Guid stoneId);

        GetProductStoneResponse GetById(Guid productId, Guid stoneId);

        PagingModel<GetProductStoneResponse> GetAll(FilterModel filterModel);

        int TotalItem();

        bool Update(GetProductStoneRequest updateCounterRequest);

        decimal CalculateStonePriceByProductId(Guid productId);
    }
}