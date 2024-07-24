using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.ProductStoneRepository
{
    public interface IProductStoneRepository
    {
        List<ProductStone> GetAll(FilterModel filterModel);

        ProductStone GetById(Guid productId, Guid stoneId);

        ProductStone Create(ProductStone productStone);
        ProductStone CreateForProduct(Guid stoneId, Guid productId);

        bool Update(ProductStone productStone);

        bool Delete(Guid productId, Guid stoneId);

        int TotalItem();

        decimal CalculateStonePriceByProductId(Guid productId);

    }
}