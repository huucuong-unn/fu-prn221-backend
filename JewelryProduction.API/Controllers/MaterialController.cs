using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Response.Material;
using JewelryProduction.Service.Service.MaterialImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class MaterialController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet(ApiEndPointConstant.Material.GET_MATERIAL_WITHOUT_PAGING)]
        public List<GetMaterialResponse> GetMaterialWithoutPaging()
        {
            return _materialService.GetMaterialWithoutPaging();
        }
    }
}
