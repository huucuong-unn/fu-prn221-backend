using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;

namespace JewelryProduction.Repository.ProductStoneRepository
{
    public class ProductStoneRepository : IProductStoneRepository
    {
        private readonly ProductStoneDAO productStoneDAO;

        public ProductStoneRepository()
        {
            if (productStoneDAO == null)
            {
                productStoneDAO = new ProductStoneDAO();
            }
        }

        public ProductStone Create(ProductStone productStone)
        {
            return productStoneDAO.Create(productStone);
        }

        public bool Delete(Guid productId, Guid stoneId)
        {
            return productStoneDAO.Delete(productId, stoneId);
        }
        

        public ProductStone GetById(Guid productId, Guid stoneId)
        {
            return productStoneDAO.GetProductStoneById(productId, stoneId);
        }

        public List<ProductStone> GetAll(FilterModel filterModel)
        {
            return productStoneDAO.GetAll(filterModel);
        }

        public bool Update(ProductStone productStone)
        {
            return productStoneDAO.Update(productStone);
        }

        public int TotalItem()
        {
            return productStoneDAO.TotalItem();
        }
    }
}