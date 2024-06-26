﻿using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

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
    }
}