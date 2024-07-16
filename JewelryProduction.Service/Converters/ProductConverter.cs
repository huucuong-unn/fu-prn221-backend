using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Product;
using JewelryProduction.Service.Response.Product;
using System;

namespace JewelryProduction.Service.Converters
{
    public class ProductConverter
    {
        public static GetProductResponse toDto(Product product)
        {
            GetProductResponse getProductResponse = new GetProductResponse();
            getProductResponse.Id = product.Id;
            getProductResponse.Name = product.Name;
            getProductResponse.Description = product.Description;
            getProductResponse.Weight = product.Weight;
            getProductResponse.MaterialId = product.MaterialId;
            getProductResponse.ProductTypeId = product.ProductTypeId;
            getProductResponse.Price = product.Price;
            getProductResponse.Status = product.Status;
            getProductResponse.CreateDate = product.CreateDate;
            getProductResponse.UpdateDate = product.UpdateDate;
            getProductResponse.CounterId = product.CounterId;
            getProductResponse.ProductTypeId = product.ProductTypeId;
            getProductResponse.ProductCode = product.ProductCode;
            getProductResponse.MaterialName = product.Material.Name;
            getProductResponse.ProductType = product.ProductType.Name;
            getProductResponse.CounterName = product.Counter.Name;
            return getProductResponse;
        }

        public static Product toEntityForCreate(GetProductRequest createProductRequest)
        {
            Product product = new Product();
            product.Name = createProductRequest.Name;
            product.Description = createProductRequest.Description;
            product.Weight = createProductRequest.Weight;
            product.MaterialId = createProductRequest.MaterialId;
            product.Price = createProductRequest.Price;
            product.Status = "ACTIVE";
            product.CreateDate = DateTime.Now;
            product.UpdateDate = DateTime.Now;
            product.CounterId = createProductRequest.CounterId;
            product.ProductTypeId = createProductRequest.ProductTypeId;
            product.ProductCode = createProductRequest.ProductCode;

            return product;
        }

        public static Product toEntityForUpdate(GetProductRequest updateProductRequest)
        {
            Product product = new Product();
            product.Name = updateProductRequest.Name;
            product.Description = updateProductRequest.Description;
            product.Weight = updateProductRequest.Weight;
            product.MaterialId = updateProductRequest.MaterialId;
            product.Price = updateProductRequest.Price;
            product.Status = updateProductRequest.Status;
            product.CreateDate = updateProductRequest.CreateDate;
            product.UpdateDate = DateTime.Now;
            product.CounterId = updateProductRequest.CounterId;
            product.ProductTypeId = updateProductRequest.ProductTypeId;
            product.ProductCode = updateProductRequest.ProductCode;
            return product;
        }
    }
}
