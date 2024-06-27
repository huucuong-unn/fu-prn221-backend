using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;

namespace JewelryProduction.Repository.ProductsRepository;

public interface IProductRepository
{
    Product Create(Product product);
        
    bool ChangeStatus(Guid id);
        
    Product GetProductById(Guid id);
        
    List<Product> GetProducts(FilterModel filterModel);

    List<Product> GetProductsByMaterialId(Guid materialId);

    public ProductType GetProductTypeById(Guid productTypeId);

    public List<ProductStone> GetProductStones(Guid productId);

    bool Update(Guid id, Product product);
        
    int TotalProducts();

    Product GetProductByProductCode(string productCode);

    public List<Product> GetProductsActiveWithoutPaging();

    public List<Product> SearchProductByProductTypeName(string product_type_name);

    public List<Product> SearchProductByProductCode(string product_code);
    public List<Product> SearchProductByMaterialName(string material_name);
    public List<Product> SearchProductByCounterName(string counter_name);
    public List<Product> SearchProductsByPrice(decimal priceFrom, decimal priceTo);

}
