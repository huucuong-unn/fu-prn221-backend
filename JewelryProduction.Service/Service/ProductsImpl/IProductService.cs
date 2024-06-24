using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Response.Product;
using JewelryProduction.Service.Response.ProductStone;
using JewelryProduction.Service.Response.ProductType;

namespace JewelryProduction.Service.Service.ProductsImpl;

public interface IProductService
{
    GetProductResponse CreateProduct(GetProductRequest request);
    bool ChangeProductStatus(Guid id);
    GetProductResponse GetProductById(Guid id);
    PagingModel<GetProductResponse> GetProducts(FilterModel filterModel);
    List<GetProductResponse> GetProductsByMaterialId (Guid id);
    GetProductTypeResponse GetProductTypeById(Guid productTypeId);
    List<GetProductStoneResponse> GetProductStones(Guid productId);
    bool UpdateProduct(Guid id, GetProductRequest request);
    int GetTotalProducts();
}