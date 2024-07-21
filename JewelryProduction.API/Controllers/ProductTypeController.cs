using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.ProductType;
using JewelryProduction.Service.Response.ProductType;
using JewelryProduction.Service.Service.ProductTypeImpl;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProductTypeion.API.Controllers
{
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet(ApiEndPointConstant.ProductType.GET_PRODUCT_TYPE)]
        public IActionResult GetProductTypes([FromQuery] int page, [FromQuery] int size)
        {
            FilterModel filterModel = new FilterModel
            {
                PageSize = size,
                PageIndex = page
            };

            PagingModel<GetProductTypeResponse> result = _productTypeService.GetProductTypes(filterModel);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.ProductType.GET_PRODUCT_TYPE_WITHOUT_PAGING)]
        public IActionResult GetProductTypeWithoutPaging()
        {
            List<GetProductTypeResponse> result = _productTypeService.GetProductTypeWithoutPaging();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.ProductType.GET_PRODUCT_TYPE_BY_ID + "{id}")]
        public IActionResult GetProductTypeById(Guid id)
        {
            GetProductTypeResponse productType = _productTypeService.GetProductTypeByIdWithDto(id);
            if (productType == null)
                return NotFound();

            return Ok(productType);
        }

        [HttpPost(ApiEndPointConstant.ProductType.CREATE_PRODUCT_TYPE)]
        public IActionResult CreateProductType([FromBody] GetProductTypeRequest createProductTypeRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetProductTypeResponse createdProductType = _productTypeService.CreateProductType(createProductTypeRequest);
            return CreatedAtAction(nameof(GetProductTypeById), new { id = createdProductType.Id }, createdProductType);
        }

        [HttpPut(ApiEndPointConstant.ProductType.UPDATE_PRODUCT_TYPE + "{id}")]
        public IActionResult UpdateProductType(Guid id, [FromBody] GetProductTypeRequest updateProductTypeRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = _productTypeService.UpdateProductType(id, updateProductTypeRequest);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete(ApiEndPointConstant.ProductType.CHANGE_STATUS_PRODUCT_TYPE + "{id}")]
        public IActionResult ChangeProductTypeStatus(Guid id)
        {
            bool result = _productTypeService.ChangeProductTypeStatus(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
