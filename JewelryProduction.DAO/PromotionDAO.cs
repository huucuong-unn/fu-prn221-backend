using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.DAO
{
    public class PromotionDAO
    {
        public PromotionDAO() { }

        public List<Promotion> GetPromotions(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Promotions
                    .Where(c => c.Status == "ACTIVE")
                    .OrderByDescending(c => c.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public Promotion? GetPromotionById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Promotions.FirstOrDefault(c => c.Id == id);
            }
        }

        public Promotion? Create(Promotion? promotion)
        {
            using (var context = new JewelryProductionContext())
            {
                promotion.Id = Guid.NewGuid();
                promotion.Status = "ACTIVE";
                context.Promotions.Add(promotion);
                context.SaveChanges();
                return promotion;
            }
        }

        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var promotion = context.Promotions.FirstOrDefault(c => c.Id == id);
                if (promotion == null)
                {
                    return false;
                }

                promotion.Status = promotion.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.Promotions.Update(promotion);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid id, Promotion promotion)
        {
            using (var context = new JewelryProductionContext())
            {
                var existingPromotion = context.Promotions.FirstOrDefault(c => c.Id == id);
                if (existingPromotion == null)
                {
                    return false;
                }
                existingPromotion.Name = promotion.Name;
                existingPromotion.StartDate = promotion.StartDate;
                existingPromotion.EndDate = promotion.EndDate;
                existingPromotion.Description = promotion.Description;
                existingPromotion.UpdateDate = promotion.UpdateDate;
                existingPromotion.UpdateBy = promotion.UpdateBy;

                context.Promotions.Update(existingPromotion);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalCounter()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Promotions.Count();
            }
        }
    }

}
