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

        [HttpGet(ApiEndPointConstant.Product.GET_PRODUCTS_ACTIVE)]
        public IActionResult GetProductsActive()
        {
            return Ok(_productService.GetProductsActive());
        }


        [HttpGet(ApiEndPointConstant.Product.SEARCH_PRODUCTS_BY_PRODUCT_TYPE_NAME)]
        public IActionResult SearchProductByProductTypeName(string product_type_name)
        {                      

            
            return Ok(_productService.SearchProductByProductTypeName(product_type_name));
        }

        [HttpGet(ApiEndPointConstant.Product.SEARCH_PRODUCTS_BY_PRODUCT_CODE)]
        public IActionResult SearchProductByProductCode(string product_code)
        {


            return Ok(_productService.SearchProductByProductCode(product_code));
        }

        [HttpGet(ApiEndPointConstant.Product.SEARCH_PRODUCTS_BY_MATERIAL_NAME)]
        public IActionResult SearchProductByMaterialName(string material_name)
        {


            return Ok(_productService.SearchProductByMaterialName(material_name));
        }

        [HttpGet(ApiEndPointConstant.Product.SEARCH_PRODUCTS_BY_COUNTER_NAME)]
        public IActionResult SearchProductByCounterName(string counter_name)
        {


            return Ok(_productService.SearchProductByCounterName(counter_name));
        }

        [HttpGet(ApiEndPointConstant.Product.SEARCH_PRODUCTS_BY_PRODUCT_PRICE)]
        public IActionResult SearchProductsByPrice([FromQuery] decimal priceFrom, [FromQuery] decimal priceTo)
        {
            if (priceFrom <= 0 || priceFrom >= 100000000 || priceTo <= 0 || priceTo >= 100000000)
            {
                return BadRequest(new { message = "Price phải lớn hơn 0 và nhỏ hơn 100,000,000" });
            }

            var products = _productService.SearchProductsByPrice(priceFrom, priceTo);
            if (products == null || products.Count == 0)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm nào trong khoảng giá này." });
            }

            return Ok(products);
        }

        [HttpGet(ApiEndPointConstant.Product.SEARCH_SORT_PRODUCT)]
        public IActionResult SearchSort(string? counter_name, string? product_code, string? product_type, string? material)
        {
            if (string.IsNullOrEmpty(counter_name) && string.IsNullOrEmpty(product_code) && string.IsNullOrEmpty(product_type) && string.IsNullOrEmpty(material))
            {
                return BadRequest("Bạn phải nhập ít nhất một giá trị.");
            }
            var products = _productService.SearchSort(counter_name, product_code, product_type, material);           

            return Ok(products);
        }

        [HttpGet(ApiEndPointConstant.Product.GET_PRODUCTS_FOR_MAKE_ORDER)]
        public IActionResult GetProductsForCustomerBuyAndStoreBuy()
        {
            return Ok(_productService.GetProductsForCustomerBuyAndStoreBuy());
        }

        [HttpGet(ApiEndPointConstant.Product.RECAL_PRODUCT)]
        public IActionResult ReCalProduct(string productCode)
        {
            return Ok(_productService.ReCalProduct(productCode));
        }
    }
}
