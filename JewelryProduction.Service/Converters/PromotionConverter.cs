using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Promotions;
using JewelryProduction.Service.Response.Promotion;

namespace JewelryProduction.Service.Converters
{
    public class PromotionConverter
    {
        public static GetPromotionResponse toDto(Promotion promotion)
        {
            GetPromotionResponse getPromotionResponse = new GetPromotionResponse();
            getPromotionResponse.Id = promotion.Id;
            getPromotionResponse.Value = promotion.Value;
            getPromotionResponse.StartDate = (DateOnly)promotion.StartDate;
            getPromotionResponse.Name = promotion.Name;
            getPromotionResponse.EndDate = (DateOnly)promotion.EndDate;
            getPromotionResponse.Description = promotion.Description;
            getPromotionResponse.Status = promotion.Status;
            getPromotionResponse.CreateDate = (DateTime)promotion.CreateDate;
            getPromotionResponse.CreateBy = promotion.CreateBy;
            getPromotionResponse.UpdateDate = (DateTime)promotion.UpdateDate;
            getPromotionResponse.UpdateBy = promotion.UpdateBy;
            return getPromotionResponse;
        }

        public static Promotion toEntityForCreate(BasePromotionRequest createPromotionRequest)
        {
            if (createPromotionRequest.Name != null && createPromotionRequest.CreateBy != null && createPromotionRequest.UpdateBy != null)
            {
                Promotion promotion = new Promotion();
                promotion.Id = new Guid();
                promotion.StartDate = createPromotionRequest.StartDate;
                promotion.Name = createPromotionRequest.Name;
                promotion.EndDate = createPromotionRequest.EndDate;
                promotion.Description = createPromotionRequest.Description;
                promotion.Status = "ACTIVE";
                promotion.CreateDate = DateTime.Now;
                promotion.CreateBy = createPromotionRequest.CreateBy;
                promotion.UpdateDate = DateTime.Now;
                promotion.UpdateBy = createPromotionRequest.UpdateBy;
                promotion.Value = createPromotionRequest.Value;
                return promotion;
            }
            return null;

        }

        public static Promotion toEntityForUpdate(BasePromotionRequest updatePromotionRequest)
        {
            Promotion promotion = new Promotion();
            promotion.StartDate = updatePromotionRequest.StartDate;
            promotion.Name = updatePromotionRequest.Name;
            promotion.EndDate = updatePromotionRequest.EndDate;
            promotion.Status = "ACTIVE";
            promotion.CreateDate = DateTime.Now;
            promotion.CreateBy = updatePromotionRequest.CreateBy;
            promotion.UpdateDate = DateTime.Now;
            promotion.UpdateBy = updatePromotionRequest.CreateBy;
            return promotion;
        }
    }
}

