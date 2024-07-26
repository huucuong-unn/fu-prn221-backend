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
        return _productDao.GetProductByProductCode(productCode);
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

    public List<Product> SearchProductByProductTypeName(string product_type_name)
    {
        return _productDao.SearchProductByProductTypeName(product_type_name);
    }
    public List<Product> SearchProductByProductCode(string product_code)
    {
        return _productDao.SearchProductByProductCode(product_code);
    }
    public List<Product> SearchProductByMaterialName(string material_name)
    {
        return _productDao.SearchProductByMaterialName(material_name);
    }
    public List<Product> SearchProductByCounterName(string counter_name)
    {
        return _productDao.SearchProductByCounterName(counter_name);
    }
    public List<Product> SearchProductsByPrice(decimal priceFrom, decimal priceTo)
    {
        return _productDao.SearchProductsByPrice(priceFrom, priceTo);
    }

    public List<Product> SearchSort(string? productCode, Guid? productTypeId, Guid? materialId, Guid? counterId, string status, FilterModel filterModel)
    {
        return _productDao.SearchProduct(productCode, productTypeId, materialId, counterId, status, filterModel);
    }


    public List<Product> GetProductsForCustomerBuyAndStoreBuy()
    {
        return _productDao.GetProductsForCustomerBuyAndStoreBuy();
    }

    public Product ReCalProduct(string productCode)
    {
        return _productDao.ReCalProduct(productCode);
    }

    public bool UpdateStatus(Guid id, string status)
    {
        return _productDao.UpdateStatus(id, status);
    }

    public bool ChangeStatusDynamic(Guid id)
    {
        return _productDao.ChangeStatusDynamic(id);
    }
}

