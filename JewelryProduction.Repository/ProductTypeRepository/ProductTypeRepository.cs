using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;

namespace JewelryProduction.Repository.ProductTypeRepository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ProductTypeDAO _productTypeDao;

        public ProductTypeRepository()
        {
            if (_productTypeDao == null)
            {
                _productTypeDao = new ProductTypeDAO();
            }
        }

        public ProductType Create(ProductType productType)
        {
            return _productTypeDao.Create(productType);
        }

        public bool ChangeStatus(Guid id)
        {
            return _productTypeDao.ChangeStatus(id);
        }

        public ProductType GetProductTypeById(Guid id)
        {
            return _productTypeDao.GetProductTypeById(id);
        }

        public List<ProductType> GetProductTypes(FilterModel filterModel)
        {
            return _productTypeDao.GetProductTypes(filterModel);
        }

        public bool Update(Guid id, ProductType productType)
        {
            return _productTypeDao.Update(id, productType);
        }

        public int TotalProductTypes()
        {
            return _productTypeDao.TotalItem();
        }
    }
}
