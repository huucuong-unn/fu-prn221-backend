using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.PromotionRepository;
using JewelryProduction.Repository.WarrantyRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Promotion;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Promotion;
using JewelryProduction.Service.Response.Warranty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.PromotionImpl
{
    public class PromotionService:IPromotionService
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
    }
}

