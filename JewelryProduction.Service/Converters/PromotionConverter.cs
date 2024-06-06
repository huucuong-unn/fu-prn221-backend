using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Request.Promotion;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Promotion;
using JewelryProduction.Service.Response.Warranty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Converters
{
    public class PromotionConverter
    {
        public static GetPromotionResponse toDto(Promotion promotion)
        {
            GetPromotionResponse getPromotionResponse = new GetPromotionResponse();
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
            Promotion promotion = new Promotion();
            promotion.StartDate = createPromotionRequest.StartDate;
            promotion.Name = createPromotionRequest.Name;
            promotion.EndDate = createPromotionRequest.EndDate;
            promotion.Status = "ACTIVE";
            promotion.CreateDate = DateTime.Now;
            promotion.CreateBy = createPromotionRequest.CreateBy;
            promotion.UpdateDate = DateTime.Now;
            promotion.UpdateBy = createPromotionRequest.CreateBy;
            return promotion;
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

