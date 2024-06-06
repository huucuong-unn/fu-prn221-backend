using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Response.Product;

namespace JewelryProduction.Service.Service.ProductsImpl;

public interface IProductService
{
    GetProductResponse CreateProduct(GetProductRequest request);
    bool ChangeProductStatus(Guid id);
    GetProductResponse GetProductById(Guid id);
    PagingModel<GetProductResponse> GetProducts(FilterModel filterModel);
    bool UpdateProduct(Guid id, GetProductRequest request);
    int GetTotalProducts();
}