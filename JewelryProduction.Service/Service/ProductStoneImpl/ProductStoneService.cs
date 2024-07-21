using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CounterRepository;
using JewelryProduction.Repository.ProductStoneRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Request.ProductStone;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.ProductStone;

namespace JewelryProduction.Service.Service.ProductStoneImpl
{
    public class ProductStoneService : IProductStoneService
    {
        private readonly IProductStoneRepository productStoneRepository;

        public ProductStoneService()
        {
            if (productStoneRepository == null)
            {
                productStoneRepository = new ProductStoneRepository();
            }
        }

        public GetProductStoneResponse Create(GetProductStoneRequest createProductStoneRequest)
        {
            BusinessObject.Models.ProductStone productStone = ProductStoneConverter.toEntityForCreate(createProductStoneRequest);
            BusinessObject.Models.ProductStone newProductStone = productStoneRepository.Create(productStone);
            return ProductStoneConverter.toDto(newProductStone);
        }

        public bool Delete (Guid productId, Guid stoneId)
        {
            return productStoneRepository.Delete(productId, stoneId);
        }

        public GetProductStoneResponse GetById(Guid productId, Guid stoneId)
        {
            BusinessObject.Models.ProductStone productStone = productStoneRepository.GetById(productId, stoneId);
            return ProductStoneConverter.toDto(productStone);
        }

        public PagingModel<GetProductStoneResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetProductStoneResponse> result = new PagingModel<GetProductStoneResponse>();
            result.Page = filterModel.PageIndex;
            List<BusinessObject.Models.ProductStone> productStones = productStoneRepository.GetAll(filterModel);
            List<GetProductStoneResponse> getProductStoneResponses = productStones.Select(productStone =>
            {
                return ProductStoneConverter.toDto(productStone);
            }).ToList();

            result.ListResult = getProductStoneResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalItem()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public int TotalItem()
        {
            return productStoneRepository.TotalItem();
        }

        public bool Update(GetProductStoneRequest updateProductStoneRequest)
        {
            BusinessObject.Models.ProductStone productStone = ProductStoneConverter.toEntityForUpdate(updateProductStoneRequest);
            return productStoneRepository.Update(productStone);
        }

        public decimal CalculateStonePriceByProductId(Guid productId)
        {
            return productStoneRepository.CalculateStonePriceByProductId(productId);
        }
    }
}
