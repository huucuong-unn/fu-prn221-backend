using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.ProductStone;
using JewelryProduction.Service.Response.ProductStone;

namespace JewelryProduction.Service.Converters
{
    public class ProductStoneConverter
    {
        public static GetProductStoneResponse toDto(ProductStone productStone)
        {
            GetProductStoneResponse getproductStoneResponse = new GetProductStoneResponse();
            getproductStoneResponse.ProductId = productStone.ProductId;
            getproductStoneResponse.StoneId = productStone.StoneId;
            getproductStoneResponse.Status = productStone.Status;
            getproductStoneResponse.CreateDate = (DateTime)productStone.CreateDate;
            getproductStoneResponse.CreateBy = productStone.CreateBy;
            getproductStoneResponse.UpdateDate = (DateTime)productStone.UpdateDate;
            getproductStoneResponse.UpdateBy = productStone.UpdateBy;
            return getproductStoneResponse;
        }

        public static ProductStone toEntityForCreate(GetProductStoneRequest createproductStoneRequest)
        {
            ProductStone productStone = new ProductStone();
            productStone.Status = "ACTIVE";
            productStone.CreateDate = DateTime.Now;
            productStone.CreateBy = createproductStoneRequest.CreateBy;
            productStone.UpdateDate = DateTime.Now;
            productStone.UpdateBy = createproductStoneRequest.UpdateBy;
            return productStone;
        }

        public static ProductStone toEntityForUpdate(GetProductStoneRequest updateproductStoneRequest)
        {
            ProductStone productStone = new ProductStone();
            productStone.Status = updateproductStoneRequest.Status;
            productStone.CreateDate = updateproductStoneRequest.CreateDate;
            productStone.CreateBy = updateproductStoneRequest.CreateBy;
            productStone.UpdateDate = DateTime.Now;
            productStone.UpdateBy = updateproductStoneRequest.UpdateBy;
            return productStone;
        }
    }
}
