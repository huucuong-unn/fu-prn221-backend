using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.ProductStone;
using JewelryProduction.Service.Response.ProductStone;
using JewelryProduction.Service.Service.ProductStoneImpl;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class ProductStoneController : ControllerBase
    {
        private readonly IProductStoneService _productStoneService;

        public ProductStoneController(IProductStoneService productStoneService)
        {
            _productStoneService = productStoneService;
        }

        [HttpGet(ApiEndPointConstant.ProductStone.GET_PRODUCT_STONE)]
        public PagingModel<GetProductStoneResponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _productStoneService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.ProductStone.GET_PRODUCT_STONE_BY_PRODUCTID_AND_STONEID + "{productId}&{stoneId}")]
        public GetProductStoneResponse GetById(Guid productId, Guid stoneId)
        {
            return _productStoneService.GetById(productId, stoneId);
        }

        [HttpPost(ApiEndPointConstant.ProductStone.CREATE_PRODUCT_STONE)]
        public GetProductStoneResponse Create(GetProductStoneRequest createProductStoneRequest)
        {
            return _productStoneService.Create(createProductStoneRequest);
        }

        [HttpPut(ApiEndPointConstant.ProductStone.UPDATE_PRODUCT_STONE)]
        public bool Update(GetProductStoneRequest updateProductStoneRequest)
        {
            return _productStoneService.Update(updateProductStoneRequest);
        }

        [HttpDelete(ApiEndPointConstant.ProductStone.DELETE_PRODUCT_STONE + "{productId}&{stoneId}")]
        public bool ChangeStatus(Guid productId, Guid stoneId)
        {
            return _productStoneService.Delete(productId, stoneId);
        }
    }
}