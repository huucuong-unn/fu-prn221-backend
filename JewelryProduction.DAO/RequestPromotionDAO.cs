using JewelryProduction.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryProduction.DAO
{
    public class RequestPromotionDAO
    {
        public RequestPromotionDAO() { }
        public List<RequestPromotion> GetRequestPromotions()
        {
            using (var context = new JewelryProductionContext())
            {
                var query = context.RequestPromotions.Include(x => x.Counter).Include(x => x.Staff).Include(x => x.Customer).OrderByDescending(r => r.CreatedDate).AsQueryable();
                return query.ToList();
            }
        }

        public RequestPromotion? GetRequestPromotionById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.RequestPromotions.Include(x => x.Counter).Include(x => x.Staff).Include(x => x.Customer).FirstOrDefault(c => c.Id == id);
            }
        }

        public RequestPromotion? Create(RequestPromotion? request)
        {
            using (var context = new JewelryProductionContext())
            {
                request.Id = Guid.NewGuid();
                context.RequestPromotions.Add(request);
                context.SaveChanges();
                return request;
            }
        }

        public void ChangeStatus(Guid id, string status)
        {
            using (var context = new JewelryProductionContext())
            {
                var request = context.RequestPromotions.FirstOrDefault(c => c.Id == id);
                request.Status = status;
                context.RequestPromotions.Update(request);
                context.SaveChanges();
            }
        }
    }
}

