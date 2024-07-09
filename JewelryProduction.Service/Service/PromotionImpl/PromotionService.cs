using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.PromotionRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Promotions;
using JewelryProduction.Service.Response.Promotion;

namespace JewelryProduction.Service.Service.PromotionImpl
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository promotionRepository;

        public PromotionService()
        {
            if (promotionRepository == null)
            {
                promotionRepository = new PromotionRepository();
            }
        }

        public GetPromotionResponse Create(BasePromotionRequest createPromotionRequest)
        {
            BusinessObject.Models.Promotion promotion = PromotionConverter.toEntityForCreate(createPromotionRequest);
            BusinessObject.Models.Promotion newPromotion = promotionRepository.Create(promotion);
            return PromotionConverter.toDto(newPromotion);
        }

        public bool ChangeStatus(Guid id)
        {
            return promotionRepository.ChangeStatus(id);
        }

        public GetPromotionResponse GetById(Guid id)
        {
            BusinessObject.Models.Promotion promotion = promotionRepository.GetPromotionById(id);
            return PromotionConverter.toDto(promotion);
        }

        public PagingModel<GetPromotionResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetPromotionResponse> result = new PagingModel<GetPromotionResponse>();
            result.Page = filterModel.PageIndex;
            List<BusinessObject.Models.Promotion> promotions = promotionRepository.GetPromotions(filterModel);
            List<GetPromotionResponse> getPromotionResponses = promotions.Select(promotions =>
            {
                return PromotionConverter.toDto(promotions);
            }).ToList();

            result.ListResult = getPromotionResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalCounter()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public int TotalCounter()
        {
            return promotionRepository.TotalCounter();
        }

        public bool Update(Guid id, BasePromotionRequest updatePromotionRequest)
        {
            BusinessObject.Models.Promotion promotion = PromotionConverter.toEntityForUpdate(updatePromotionRequest);
            return promotionRepository.Update(id, promotion);
        }

        public PagingModel<GetPromotionResponse> GetAllForAdmin(string? promotionName, string? status, DateOnly? startDate, DateOnly? endDate, int page, int limit)
        {
            PagingModel<GetPromotionResponse> result = new PagingModel<GetPromotionResponse>();
            result.Page = page;
            List<BusinessObject.Models.Promotion> promotions = promotionRepository.GetPromotionsForAdmin(promotionName, status, startDate, endDate, page, limit);
            List<GetPromotionResponse> getPromotionResponses = promotions.Select(promotions =>
            {
                return PromotionConverter.toDto(promotions);
            }).ToList();

            result.ListResult = getPromotionResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalCounter()) / limit));
            result.Size = promotions.Count;
            return result;
        }
    }
}

