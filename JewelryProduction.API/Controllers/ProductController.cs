using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Response.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using JewelryProduction.Service.Service.ProductsImpl;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(ApiEndPointConstant.Product.GET_PRODUCT)]
        public IActionResult GetProducts([FromQuery] int page, [FromQuery] int size)
        {
            FilterModel filterModel = new FilterModel
            {
                PageSize = size,
                PageIndex = page
            };

            PagingModel<GetProductResponse> result = _productService.GetProducts(filterModel);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Product.GET_PRODUCT_BY_ID + "{id}")]
        public IActionResult GetProductById(Guid id)
        {
            GetProductResponse product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost(ApiEndPointConstant.Product.CREATE_PRODUCT)]
        public IActionResult CreateProduct([FromBody] GetProductRequest createProductRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GetProductResponse createdProduct = _productService.CreateProduct(createProductRequest);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut(ApiEndPointConstant.Product.UPDATE_PRODUCT + "{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] GetProductRequest updateProductRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool result = _productService.UpdateProduct(id, updateProductRequest);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete(ApiEndPointConstant.Product.CHANGE_STATUS_PRODUCT + "{id}")]
        public IActionResult ChangeProductStatus(Guid id)
        {
            bool result = _productService.ChangeProductStatus(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
