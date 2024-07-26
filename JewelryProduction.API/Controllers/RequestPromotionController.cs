using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Response.RequestPromotion;
using JewelryProduction.Service.Service.RequestPromotionImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    public class RequestPromotionController : ControllerBase
    {
        private readonly IRequestPromotionService _requestService;

        public RequestPromotionController(IRequestPromotionService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet(ApiEndPointConstant.RequestPromotion.GET_REQUEST_PROMOTIONS)]
        public List<GetRequestPromotionResponse> GetAll()
        {
            return _requestService.GetRequestPromotions();
        }

        [HttpGet(ApiEndPointConstant.RequestPromotion.GET_REQUEST_PROMOTION + "/{id}")]
        public GetRequestPromotionResponse GetById(Guid id)
        {
            return _requestService.GetRequestPromotionById(id);
        }

        [HttpPost(ApiEndPointConstant.RequestPromotion.CREATE_REQUEST)]
        public GetRequestPromotionResponse Create(RequestPromotion createRequestPromotionRequest)
        {
            return _requestService.Create(createRequestPromotionRequest);
        }

        [HttpDelete(ApiEndPointConstant.RequestPromotion.CHANGE_STATUS_REQUEST_PROMOTION)]
        public void ChangeStatus([FromQuery] Guid id, [FromQuery] string status)
        {
            _requestService.ChangeStatus(id, status);
        }
    }
}
