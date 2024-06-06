/*
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.DAO
{
    public class ProductStoneDAO
    {
        public ProductStoneDAO() { }

        public List<ProductStone> GetAllProductStone()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStone.ToList();
            }
        }

        public ProductStone GetProductStoneById(Guid productId, Guid stoneId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStone.FirstOrDefault(ps => ps.ProductId == productId && ps.StoneId == stoneId);
            }
        }

        public List<ProductStone> GetProductStoneByProductId(Guid productId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStone.Where(ps => ps.ProductId == productId).ToList();
            }
        }

        public List<ProductStone> GetProductStoneByStoneId(Guid stoneId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStone.Where(ps => ps.StoneId == stoneId).ToList();
            }
        }

        public ProductStone Create(ProductStone productStone)
        {
            using (var context = new JewelryProductionContext())
            {
                context.ProductStone.Add(productStone);
                context.SaveChanges();
                return productStone;
            }
        }

        public bool Update(ProductStone productStone)
        {
            using (var context = new JewelryProductionContext())
            {
                var existingProductStone = context.ProductStone.FirstOrDefault(ps => ps.ProductId == productStone.ProductId && ps.StoneId == productStone.StoneId);
                if (existingProductStone == null)
                {
                    return false;
                }

                // Update properties here if there are any to update
                context.ProductStone.Update(existingProductStone);
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid productId, Guid stoneId)
        {
            using (var context = new JewelryProductionContext())
            {
                var productStone = context.ProductStone.FirstOrDefault(ps => ps.ProductId == productId && ps.StoneId == stoneId);
                if (productStone == null)
                {
                    return false;
                }

                context.ProductStone.Remove(productStone);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalItem()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStone.Count();
            }
        }
    }
}
*/
