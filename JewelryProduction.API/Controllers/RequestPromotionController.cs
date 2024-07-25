using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Service.RequestPromotionImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{

    [ApiController]
    public class RequestPromotionController : ControllerBase
    {
        private readonly IRequestPromotionImpl _requestService;

        public RequestPromotionController(IRequestPromotionImpl counterService)
        {
            _requestService = counterService;
        }

        [HttpGet(ApiEndPointConstant.RequestPromotion.GET_REQUEST_PROMOTIONS)]
        public List<RequestPromotion> GetAll(int page, int size)
        {
            return _requestService.GetRequestPromotions();
        }

        [HttpGet(ApiEndPointConstant.RequestPromotion.GET_REQUEST_PROMOTION + "{id}")]
        public RequestPromotion GetById(Guid id)
        {
            return _requestService.GetRequestPromotionById(id);
        }

        [HttpPost(ApiEndPointConstant.RequestPromotion.CREATE_REQUEST)]
        public RequestPromotion Create(RequestPromotion createRequestPromotionRequest)
        {
            return _requestService.Create(createRequestPromotionRequest);
        }

        [HttpDelete(ApiEndPointConstant.RequestPromotion.CHANGE_STATUS_REQUEST_PROMOTION + "{id}")]
        public void ChangeStatus(Guid id, string status)
        {
            _requestService.ChangeStatus(id, status);
        }
    }
}
