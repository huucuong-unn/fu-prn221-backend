using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.ProductType;
using JewelryProduction.Service.Response.ProductType;

namespace JewelryProduction.Service.Service.ProductTypeImpl
{
    public interface IProductTypeService
    {
        GetProductTypeResponse CreateProductType(GetProductTypeRequest request);
        bool ChangeProductTypeStatus(Guid id);
        GetProductTypeResponse GetProductTypeById(Guid id);
        PagingModel<GetProductTypeResponse> GetProductTypes(FilterModel filterModel);
        bool UpdateProductType(Guid id, GetProductTypeRequest request);
        int GetTotalProductTypes();
    }
}
