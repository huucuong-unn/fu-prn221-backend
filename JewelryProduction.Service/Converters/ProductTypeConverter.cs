using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.ProductType;
using JewelryProduction.Service.Response.ProductType;

namespace JewelryProduction.Service.Converters
{
    public static class ProductTypeConverter
    {
        public static GetProductTypeResponse ToDto(ProductType productType)
        {
            if (productType == null)
            {
                throw new ArgumentNullException(nameof(productType));
            }

            return new GetProductTypeResponse
            {
                Id = productType.Id,
                Name = productType.Name,
                Wages = productType.Wages,
                Status = productType.Status,
                CreateDate = productType.CreateDate,
                CreateBy = productType.CreateBy,
                UpdateDate = productType.UpdateDate,
                UpdateBy = productType.UpdateBy
            };
        }

        public static ProductType ToEntityForCreate(GetProductTypeRequest createProductTypeRequest)
        {
            if (createProductTypeRequest == null)
            {
                throw new ArgumentNullException(nameof(createProductTypeRequest));
            }

            return new ProductType
            {
                Id = Guid.NewGuid(),
                Name = createProductTypeRequest.Name,
                Wages = createProductTypeRequest.Wages,
                Status = "ACTIVE",
                CreateDate = DateTime.Now,
                CreateBy = createProductTypeRequest.CreateBy,
                UpdateDate = DateTime.Now,
                UpdateBy = createProductTypeRequest.CreateBy,
                Products = new List<Product>()
            };
        }

        public static ProductType ToEntityForUpdate(GetProductTypeRequest updateProductTypeRequest)
        {
            if (updateProductTypeRequest == null)
            {
                throw new ArgumentNullException(nameof(updateProductTypeRequest));
            }

            return new ProductType
            {
                Id = updateProductTypeRequest.Id,
                Name = updateProductTypeRequest.Name,
                Wages = updateProductTypeRequest.Wages,
                Status = updateProductTypeRequest.Status,
                CreateDate = updateProductTypeRequest.CreateDate,
                CreateBy = updateProductTypeRequest.CreateBy,
                UpdateDate = DateTime.Now,
                UpdateBy = updateProductTypeRequest.UpdateBy,
                Products = new List<Product>()  // Assuming you may want to handle this differently based on your logic
            };
        }
    }
}
