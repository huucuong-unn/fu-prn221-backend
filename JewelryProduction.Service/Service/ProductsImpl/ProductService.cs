using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.DAO;
using JewelryProduction.Repository.MaterialRepository;
using JewelryProduction.Repository.ProductsRepository;
using JewelryProduction.Repository.ProductStoneRepository;
using JewelryProduction.Repository.ProductTypeRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Response.Product;
using JewelryProduction.Service.Response.ProductStone;
using JewelryProduction.Service.Response.ProductType;
using JewelryProduction.Service.Service.ProductStoneImpl;
using static JewelryProduction.Service.Constant.ApiEndPointConstant;

namespace JewelryProduction.Service.Service.ProductsImpl;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMaterialRepository _materialRepository;
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly IProductStoneRepository _productStoneRepository;

    public ProductService()
    {
        if (_productRepository == null)
        {
            _productRepository = new ProductRepository();
            _materialRepository = new MaterialRepository();
            _productTypeRepository = new ProductTypeRepository();
            _productStoneRepository = new ProductStoneRepository();
        }
    }

    public GetProductResponse CreateProduct(GetProductRequest createProductRequest)
    {
        BusinessObject.Models.Product product = ProductConverter.toEntityForUpdate(createProductRequest);
        BusinessObject.Models.Product newProduct = _productRepository.Create(product);
        BusinessObject.Models.Product productById = _productRepository.GetProductById(newProduct.Id);
        foreach (var stoneId in createProductRequest.StoneIds)
        {
            _productStoneRepository.CreateForProduct(stoneId, productById.Id);
        }
        UpdatePriceForProduct((Guid)productById.MaterialId, productById.ProductTypeId, productById.Id);
        return ProductConverter.toDto(productById);
    }

    private void UpdatePriceForProduct(Guid materialId, Guid productTypeId, Guid productId)
    {
        BusinessObject.Models.Material materialById = _materialRepository.GetById(materialId);
        decimal buyingPrice = materialById.BuyingPrice;
        BusinessObject.Models.ProductType productTypeById = _productTypeRepository.GetProductTypeById(productTypeId);
        var stonePrices = _productStoneRepository.CalculateStonePriceByProductId(productId);
        BusinessObject.Models.Product productById = _productRepository.GetProductById(productId);
        productById.Price = (buyingPrice * (productById.Weight / 1000)) + productTypeById.Wages + stonePrices;

        _productRepository.Update(productById.Id, productById);
    }

    public bool ChangeProductStatus(Guid id)
    {
        return _productRepository.ChangeStatus(id);
    }

    public GetProductResponse GetProductById(Guid id)
    {
        BusinessObject.Models.Product product = _productRepository.GetProductById(id);
        return ProductConverter.toDto(product);
    }

    public PagingModel<GetProductResponse> GetProducts(FilterModel filterModel)
    {
        PagingModel<GetProductResponse> result = new PagingModel<GetProductResponse>();
        result.Page = filterModel.PageIndex;
        List<BusinessObject.Models.Product> products = _productRepository.GetProducts(filterModel);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        result.ListResult = getProductResponses;
        result.TotalPages = (int)Math.Ceiling((double)_productRepository.TotalProducts() / filterModel.PageSize);
        result.Size = filterModel.PageSize;
        return result;
    }

    public PagingModel<GetProductResponse> SearchSort(string? productCode, Guid? productTypeId, Guid? materialId, Guid? counterId, string status, FilterModel filterModel)
    {
        PagingModel<GetProductResponse> result = new PagingModel<GetProductResponse>();
        result.Page = filterModel.PageIndex;
        List<BusinessObject.Models.Product> products = _productRepository.SearchSort(productCode, productTypeId, materialId, counterId, status, filterModel);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        result.ListResult = getProductResponses;
        result.TotalPages = (int)Math.Ceiling((double)_productRepository.TotalProducts() / filterModel.PageSize);
        result.Size = filterModel.PageSize;

        return result;
    }

    public int GetTotalProducts()
    {
        return _productRepository.TotalProducts();
    }

    public bool UpdateProduct(Guid id, GetProductRequest updateProductRequest)
    {
        BusinessObject.Models.Product product = ProductConverter.toEntityForCreate(updateProductRequest);
        return _productRepository.Update(id, product);
    }

    public List<BusinessObject.Models.Product> GetProductsByMaterialId(Guid id)
    {
        return _productRepository.GetProductsByMaterialId(id);
    }

    public GetProductTypeResponse GetProductTypeById(Guid productTypeId)
    {
        BusinessObject.Models.ProductType productType = _productRepository.GetProductTypeById(productTypeId);
        return ProductTypeConverter.ToDto(productType);
    }

    public List<GetProductStoneResponse> GetProductStones(Guid productId)
    {
        List<BusinessObject.Models.ProductStone> productStones = _productRepository.GetProductStones(productId);
        List<GetProductStoneResponse> getProductStoneResponses = productStones.Select(product =>
        {
            return ProductStoneConverter.toDto(product);
        }).ToList();

        return getProductStoneResponses;
    }

    public List<GetProductResponse> GetProductsActive()
    {
        List<BusinessObject.Models.Product> products = _productRepository.GetProductsActiveWithoutPaging();
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();
        return getProductResponses;
    }

    public List<GetProductResponse> SearchProductByProductTypeName(string product_type_name)
    {
        List<BusinessObject.Models.Product> products = _productRepository.SearchProductByProductTypeName(product_type_name);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }

    public List<GetProductResponse> SearchProductByProductCode(string product_code)
    {
        List<BusinessObject.Models.Product> products = _productRepository.SearchProductByProductCode(product_code);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }

    public List<GetProductResponse> SearchProductByMaterialName(string material_name)
    {
        List<BusinessObject.Models.Product> products = _productRepository.SearchProductByMaterialName(material_name);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }
   

    public List<GetProductResponse> SearchProductsByPrice(decimal priceFrom, decimal priceTo)
    {

        List<BusinessObject.Models.Product> products = _productRepository.SearchProductsByPrice(priceFrom, priceTo);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }

    public List<GetProductResponse> GetProductsForCustomerBuyAndStoreBuy()
    {
        List<BusinessObject.Models.Product> products = _productRepository.GetProductsForCustomerBuyAndStoreBuy();
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }

    public GetProductResponse ReCalProduct(string productCode)
    {
        BusinessObject.Models.Product product = _productRepository.ReCalProduct(productCode);          
        return ProductConverter.toDto(product);
    }
    public List<GetProductResponse> SearchProductByCounterName(string counter_name)
    {
        List<BusinessObject.Models.Product> products = _productRepository.SearchProductByCounterName(counter_name);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }

}