using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Promotion> GetPromotionsForAdmin(string? promotionName, string? status, DateOnly? startDate, DateOnly? endDate, int page, int limit)
        {
            using (var context = new JewelryProductionContext())
            {
                // Ensure AsNoTracking for read-only query optimization
                var query = context.Promotions.AsNoTracking().AsQueryable();

                if (!string.IsNullOrEmpty(promotionName))
                {
                    query = query.Where(p => p.Name.Contains(promotionName));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(p => p.Status == status);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(p => p.StartDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(p => p.EndDate <= endDate.Value);
                }

                return query
                    .OrderByDescending(p => p.CreateDate)
                    .Skip((page - 1) * limit)
                    .Take(limit)
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
                promotion.CreateDate = DateTime.Now;
                promotion.UpdateDate = DateTime.Now;
                promotion.UpdateBy = promotion.UpdateBy;
                promotion.CreateBy = "hello";
                context.Promotions.Add(promotion);
                context.SaveChanges();
                return promotion;
            }
        }

        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var result = false;
                var promotion = context.Promotions.FirstOrDefault(c => c.Id == id);
                var promotionActive = FindByStatusTrue();
                if (promotion == null)
                {
                    result = false;
                }
                if (promotionActive == null)
                {
                    promotion.Status = "ACTIVE";
                    result = true;

                }
                else if (promotion.Id == promotionActive.Id)
                {
                    promotion.Status = "INACTIVE";
                    result = true;
                }
                if (result == true)
                {
                    context.Promotions.Update(promotion);
                    context.SaveChanges();
                }

                return result;
            }
        }

        public Promotion FindByStatusTrue()
        {
            using (var context = new JewelryProductionContext())
            {
                var promotion = context.Promotions.FirstOrDefault(c => c.Status == "ACTIVE");
                if (promotion == null)
                {
                    return null;
                }
                return promotion;
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
