using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.ProductTypeRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.ProductType;
using JewelryProduction.Service.Response.ProductType;

namespace JewelryProduction.Service.Service.ProductTypeImpl
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService()
        {
            if (_productTypeRepository == null)
            {
                _productTypeRepository = new ProductTypeRepository();
            }
        }

        public GetProductTypeResponse CreateProductType(GetProductTypeRequest createProductTypeRequest)
        {
            BusinessObject.Models.ProductType productType = ProductTypeConverter.ToEntityForUpdate(createProductTypeRequest);
            BusinessObject.Models.ProductType newProduct = _productTypeRepository.Create(productType);
            return ProductTypeConverter.ToDto(newProduct);
        }

        public bool ChangeProductTypeStatus(Guid id)
        {
            return _productTypeRepository.ChangeStatus(id);
        }

        public GetProductTypeResponse GetProductTypeById(Guid id)
        {
            BusinessObject.Models.ProductType productType = _productTypeRepository.GetProductTypeById(id);
            return ProductTypeConverter.ToDto(productType);
        }

        public PagingModel<GetProductTypeResponse> GetProductTypes(FilterModel filterModel)
        {
            PagingModel<GetProductTypeResponse> result = new PagingModel<GetProductTypeResponse>();
            result.Page = filterModel.PageIndex;
            List<BusinessObject.Models.ProductType> productTypes = _productTypeRepository.GetProductTypes(filterModel);
            List<GetProductTypeResponse> getProductTypeResponses = productTypes.Select(productType =>
            {
                return ProductTypeConverter.ToDto(productType);
            }).ToList();

            result.ListResult = getProductTypeResponses;
            result.TotalPages = (int)Math.Ceiling((double)_productTypeRepository.TotalProductTypes() / filterModel.PageSize);
            result.Size = filterModel.PageSize;
            return result;
        }

        public int GetTotalProductTypes()
        {
            return _productTypeRepository.TotalProductTypes();
        }

        public bool UpdateProductType(Guid id, GetProductTypeRequest updateProductTypeRequest)
        {
            ProductType productType = ProductTypeConverter.ToEntityForCreate(updateProductTypeRequest);
            return _productTypeRepository.Update(id, productType);
        }
    }
}