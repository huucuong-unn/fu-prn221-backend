using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Warranty;
using JewelryProduction.Service.Service.Counter;
using JewelryProduction.Service.Service.WarrantyImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    public class WarrantyController:ControllerBase
    {
        private readonly IWarrantyService _warrantyService;

        public WarrantyController(IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService;
        }

        [HttpGet(ApiEndPointConstant.Warranty.GET_WARRANTY)]
        public PagingModel<GetWarrantyResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _warrantyService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.Warranty.GET_WARRANTY_BY_ID + "{id}")]
        public GetWarrantyResponse GetById(Guid id)
        {
            return _warrantyService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.Warranty.CREATE_WARRANTY)]
        public GetWarrantyResponse Create(BaseWarrantyRequest createWarrantyRequest)
        {
            return _warrantyService.Create(createWarrantyRequest);
        }

        [HttpPut(ApiEndPointConstant.Warranty.UPDATE_WARRANTY + "{id}")]
        public bool Update(Guid id, BaseWarrantyRequest updateWarrantyRequest)
        {
            return _warrantyService.Update(id, updateWarrantyRequest);
        }

        [HttpDelete(ApiEndPointConstant.Warranty.CHANGE_STATUS_WARRANTY + "{id}")]
        public bool ChangeStatus(Guid id)
        {
            return _warrantyService.ChangeStatus(id);
        }
    }
}
