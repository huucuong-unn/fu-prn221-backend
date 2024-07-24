using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.Stone;
using JewelryProduction.Service.Response.Stone;
using JewelryProduction.Service.Service.Stone;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class StoneController : ControllerBase
    {
        private readonly IStoneService _stoneService;

        public StoneController(IStoneService stoneService)
        {
            _stoneService = stoneService;
        }

        [HttpGet(ApiEndPointConstant.Stone.GET_STONE)]
        public PagingModel<GetStoneResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _stoneService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.Stone.GET_STONE_WITHOUT_PAGING)]
        public List<GetStoneResponse> GetAllWithoutPaging()
        {
            return _stoneService.GetStonesWithoutPaging();
        }

        [HttpGet(ApiEndPointConstant.Stone.GET_STONE_BY_ID + "{id}")]
        public GetStoneResponse GetById(Guid id)
        {
            return _stoneService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.Stone.CREATE_STONE)]
        public GetStoneResponse Create(GetStoneRequest createStoneRequest)
        {
            return _stoneService.Create(createStoneRequest);
        }

        [HttpPut(ApiEndPointConstant.Stone.UPDATE_STONE + "{id}")]
        public bool Update(Guid id, GetStoneRequest updateStoneRequest)
        {
            return _stoneService.Update(id, updateStoneRequest);
        }

        [HttpDelete(ApiEndPointConstant.Stone.CHANGE_STATUS_STONE + "{id}")]
        public bool ChangeStatus(Guid id)
        {
            return _stoneService.ChangeStatus(id);
        }
    }
}