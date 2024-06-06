using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.DAO
{
    public class ProductDAO
    {
        public ProductDAO() { }

        public List<Product> GetProducts(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Where(p => p.Status == "ACTIVE")
                    .OrderByDescending(p => p.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public Product GetProductById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products.FirstOrDefault(p => p.Id.Equals(id));
            }
        }

        public Product Create(Product product)
        {
            using (var context = new JewelryProductionContext())
            {
                product.Id = Guid.NewGuid();
                product.Status = "ACTIVE";
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id.Equals(id));
                if (product == null)
                {
                    return false;
                }

                product.Status = product.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid id, Product updatedProduct)
        {
            using (var context = new JewelryProductionContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id.Equals(id));
                if (product == null)
                {
                    return false;
                }

                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Weight = updatedProduct.Weight;
                product.Material = updatedProduct.Material;
                product.Price = updatedProduct.Price;
                product.CreateDate = updatedProduct.CreateDate;
                product.UpdateDate = updatedProduct.UpdateDate;
                product.Status = updatedProduct.Status;
                // Other properties...

                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalItem()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products.Count();
            }
        }
    }
}
