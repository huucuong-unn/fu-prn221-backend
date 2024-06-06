using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.ProductsRepository;

public interface IProductRepository
{
    Product Create(Product product);
        
    bool ChangeStatus(Guid id);
        
    Product GetProductById(Guid id);
        
    List<Product> GetProducts(FilterModel filterModel);
        
    bool Update(Guid id, Product product);
        
    int TotalProducts();
}
