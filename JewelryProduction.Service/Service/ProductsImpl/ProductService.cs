using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.ProductsRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Response.Product;
using JewelryProduction.Service.Response.ProductStone;
using JewelryProduction.Service.Response.ProductType;

namespace JewelryProduction.Service.Service.ProductsImpl;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            if (_productRepository == null)
            {
                _productRepository = new ProductRepository();
            }
        }

        public GetProductResponse CreateProduct(GetProductRequest createProductRequest)
        {
            BusinessObject.Models.Product product = ProductConverter.toEntityForUpdate(createProductRequest);
            BusinessObject.Models.Product newProduct = _productRepository.Create(product);
            return ProductConverter.toDto(newProduct);
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

        public  PagingModel<GetProductResponse>GetProducts(FilterModel filterModel)
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

        public int GetTotalProducts()
        {
            return _productRepository.TotalProducts();
        }

        public bool UpdateProduct(Guid id, GetProductRequest updateProductRequest)
        {
            BusinessObject.Models.Product product = ProductConverter.toEntityForCreate(updateProductRequest);
            return _productRepository.Update(id, product);
        }

    public List<GetProductResponse> GetProductsByMaterialId(Guid id)
    {
        List<Product> products = _productRepository.GetProductsByMaterialId(id);
        List<GetProductResponse> getProductResponses = products.Select(product =>
        {
            return ProductConverter.toDto(product);
        }).ToList();

        return getProductResponses;
    }

    public GetProductTypeResponse GetProductTypeById(Guid productTypeId)
    {
        ProductType productType = _productRepository.GetProductTypeById(productTypeId);
        return ProductTypeConverter.ToDto(productType);
    }

    public List<GetProductStoneResponse> GetProductStones(Guid productId)
    {
        List<ProductStone> productStones = _productRepository.GetProductStones(productId);
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
}