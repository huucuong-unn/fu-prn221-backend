using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.ProductTypeRepository;

public interface IProductTypeRepository
{
    ProductType Create(ProductType productType);

    bool ChangeStatus(Guid id);

    ProductType GetProductTypeById(Guid id);

    List<ProductType> GetProductTypes(FilterModel filterModel);

    public List<ProductType> GetAllProductTypes();

    bool Update(Guid id, ProductType productType);

    int TotalProductTypes();
}

