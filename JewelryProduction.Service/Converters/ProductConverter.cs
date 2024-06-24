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
            /*getProductResponse.Material = product.Material;*/
            getProductResponse.ProductTypeId = product.ProductTypeId;
            getProductResponse.Price = product.Price;
            getProductResponse.Status = product.Status;
            getProductResponse.CreateDate = (DateTime)product.CreateDate;
            getProductResponse.UpdateDate = (DateTime)product.UpdateDate;
            return getProductResponse;
        }

        public static Product toEntityForCreate(GetProductRequest createProductRequest)
        {
            Product product = new Product();
            product.Name = createProductRequest.Name;
            product.Description = createProductRequest.Description;
            product.Weight = createProductRequest.Weight;
            /*product.Material = createProductRequest.Material;*/
            product.Price = createProductRequest.Price;
            product.Status = "ACTIVE";
            product.CreateDate = DateTime.Now;
            product.UpdateDate = DateTime.Now;
            return product;
        }

        public static Product toEntityForUpdate(GetProductRequest updateProductRequest)
        {
            Product product = new Product();
            product.Name = updateProductRequest.Name;
            product.Description = updateProductRequest.Description;
            product.Weight = updateProductRequest.Weight;
            /*product.Material = updateProductRequest.Material;*/
            product.Price = updateProductRequest.Price;
            product.Status = updateProductRequest.Status;
            product.CreateDate = updateProductRequest.CreateDate;
            product.UpdateDate = DateTime.Now;
            return product;
        }
    }
}
