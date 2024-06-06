using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Request.Promotion;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Promotion;
using JewelryProduction.Service.Response.Warranty;
using JewelryProduction.Service.Service.Counter;
using JewelryProduction.Service.Service.PromotionImpl;
using JewelryProduction.Service.Service.WarrantyImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    public class PromotionController:ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet(ApiEndPointConstant.Promotion.GET_PROMOTION)]
        public PagingModel<GetPromotionResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _promotionService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.Promotion.GET_PROMOTION_BY_ID + "{id}")]
        public GetPromotionResponse GetById(Guid id)
        {
            return _promotionService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.Promotion.CREATE_PROMOTION)]
        public GetPromotionResponse Create(BasePromotionRequest createPromotionRequest)
        {
            return _promotionService.Create(createPromotionRequest);
        }

        [HttpPut(ApiEndPointConstant.Promotion.UPDATE_PROMOTION + "{id}")]
        public bool Update(Guid id, BasePromotionRequest updatePromotionRequest)
        {
            return _promotionService.Update(id, updatePromotionRequest);
        }

        [HttpDelete(ApiEndPointConstant.Promotion.CHANGE_STATUS_PROMOTION + "{id}")]
        public bool ChangeStatus(Guid id)
        {
            return _promotionService.ChangeStatus(id);
        }
    }
}
