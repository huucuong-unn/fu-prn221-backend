using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;

namespace JewelryProduction.Repository.ProductsRepository;

public class ProductRepository : IProductRepository
{
    private readonly ProductDAO _productDao;

    public ProductRepository()
    {
        if (_productDao == null)
        {
            _productDao = new ProductDAO();
        }
    }

    public Product Create(Product product)
    {
        return _productDao.Create(product);
    }

    public bool ChangeStatus(Guid id)
    {
        return _productDao.ChangeStatus(id);
    }

    public Product GetProductById(Guid id)
    {
        return _productDao.GetProductById(id);
    }

    public List<Product> GetProducts(FilterModel filterModel)
    {
        return _productDao.GetProducts(filterModel);
    }

    public bool Update(Guid id, Product product)
    {
        return _productDao.Update(id, product);
    }

    public int TotalProducts()
    {
        return _productDao.TotalItem();
    }

    public List<Product> GetProductsByMaterialId(Guid materialId)
    {
        return _productDao.GetProductsByMaterialId(materialId);
    }

    public ProductType GetProductTypeById(Guid productTypeId)
    {
        return _productDao.GetProductTypeById(productTypeId);
    }

    public List<ProductStone> GetProductStones(Guid productId)
    {
        return _productDao.GetProductStones(productId);
    }
}

