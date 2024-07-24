using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryProduction.DAO
{
    public class ProductStoneDAO
    {
        public ProductStoneDAO() { }

        public List<ProductStone> GetAll(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones
                    .Where(p => p.Status == "ACTIVE")
                    .OrderByDescending(p => p.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public ProductStone GetProductStoneById(Guid productId, Guid stoneId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones.FirstOrDefault(ps => ps.ProductId == productId && ps.StoneId == stoneId);
            }
        }

        public List<ProductStone> GetProductStoneByProductId(Guid productId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones.Where(ps => ps.ProductId == productId).ToList();
            }
        }

        public List<ProductStone> GetProductStoneByStoneId(Guid stoneId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones.Where(ps => ps.StoneId == stoneId).ToList();
            }
        }

        public ProductStone Create(ProductStone productStone)
        {
            using (var context = new JewelryProductionContext())
            {
                productStone.CreateDate = DateTime.Now;
                productStone.UpdateDate = DateTime.Now;
                productStone.CreateBy = "admin";
                productStone.UpdateBy = "admin";
                productStone.Status = "ACTIVE";
                context.ProductStones.Add(productStone);
                context.SaveChanges();
                return productStone;
            }
        }

        public ProductStone CreateForProduct(Guid stoneId, Guid productId)
        {
            using (var context = new JewelryProductionContext())
            {
                ProductStone productStone = new ProductStone();
                productStone.ProductId = productId;
                productStone.StoneId = stoneId;
                productStone.CreateDate = DateTime.Now;
                productStone.UpdateDate = DateTime.Now;
                productStone.CreateBy = "admin";
                productStone.UpdateBy = "admin";
                productStone.Status = "ACTIVE";
                context.ProductStones.Add(productStone);
                context.SaveChanges();
                return productStone;
            }
        }

        public bool Update(ProductStone productStone)
        {
            using (var context = new JewelryProductionContext())
            {
                var existingProductStone = context.ProductStones.FirstOrDefault(ps => ps.ProductId == productStone.ProductId && ps.StoneId == productStone.StoneId);
                if (existingProductStone == null)
                {
                    return false;
                }

                // Update properties here if there are any to update
                context.ProductStones.Update(existingProductStone);
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid productId, Guid stoneId)
        {
            using (var context = new JewelryProductionContext())
            {
                var productStone = context.ProductStones.FirstOrDefault(ps => ps.ProductId == productId && ps.StoneId == stoneId);
                if (productStone == null)
                {
                    return false;
                }

                context.ProductStones.Remove(productStone);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalItem()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones.Count();
            }
        }

        public decimal CalculateStonePriceByProductId(Guid productId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones.Where(ps => ps.ProductId
                                            .Equals(productId))
                                            .Include(ps => ps.Stone)
                                            .ToList()
                                            .Sum(ps => ps.Stone != null ? ps.Stone.Price : 0);
            }
        }
    }
}