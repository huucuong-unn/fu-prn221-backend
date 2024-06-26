using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using Microsoft.EntityFrameworkCore;

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

    public Product ProductByProductCode(string productCode)
    {
        return _productDao.GetProductByProductCode(productCode);
    }

    public List<Product> GetProductsActiveWithoutPaging()
    {
        return _productDao.GetProductsActiveWithoutPaging();
    }

    public Product GetProductByProductCode(string productCode)
    {
        return _productDao.GetProductByProductCode(productCode) ;
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

    public List<Product> SearchProductsByName(string name)
    {
        return _productDao.SearchProductByName(name);
    }

}

