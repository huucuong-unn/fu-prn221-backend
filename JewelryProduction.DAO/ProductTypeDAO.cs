using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.DAO
{
    public class ProductTypeDAO
    {
        public ProductTypeDAO() { }

        public List<ProductType> GetProductTypes(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductTypes
                    .Where(pt => pt.Status == "ACTIVE")
                    .OrderByDescending(pt => pt.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public List<ProductType> GetAllProductTypes()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductTypes
                    .Where(pt => pt.Status == "ACTIVE")
                    .OrderByDescending(pt => pt.CreateDate)
                    .ToList();
            }
        }

        public ProductType GetProductTypeById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductTypes.FirstOrDefault(pt => pt.Id.Equals(id));
            }
        }

        public ProductType Create(ProductType productType)
        {
            using (var context = new JewelryProductionContext())
            {
                productType.Id = Guid.NewGuid();
                productType.Status = "ACTIVE";
                context.ProductTypes.Add(productType);
                context.SaveChanges();
                return productType;
            }
        }

        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var productType = context.ProductTypes.FirstOrDefault(pt => pt.Id.Equals(id));
                if (productType == null)
                {
                    return false;
                }

                productType.Status = productType.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.ProductTypes.Update(productType);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid id, ProductType updatedProductType)
        {
            using (var context = new JewelryProductionContext())
            {
                var productType = context.ProductTypes.FirstOrDefault(pt => pt.Id.Equals(id));
                if (productType == null)
                {
                    return false;
                }

                productType.Name = updatedProductType.Name;
                productType.Wages = updatedProductType.Wages;
                productType.Status = updatedProductType.Status;
                productType.CreateDate = updatedProductType.CreateDate;
                productType.CreateBy = updatedProductType.CreateBy;
                productType.UpdateDate = updatedProductType.UpdateDate;
                productType.UpdateBy = updatedProductType.UpdateBy;
                // Other properties...

                context.ProductTypes.Update(productType);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalItem()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductTypes.Count();
            }
        }
    }
}
