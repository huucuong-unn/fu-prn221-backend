using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.DAO
{
    public class RequestPromotionDAO
    {
        public RequestPromotionDAO() { }
        public List<RequestPromotion> GetRequestPromotions()
        {
            using (var context = new JewelryProductionContext())
            {
                var query = context.RequestPromotions.OrderByDescending(r => r.CreatedDate).AsQueryable();
                return query.ToList();
            }
        }

        public RequestPromotion? GetRequestPromotionById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.RequestPromotions.FirstOrDefault(c => c.Id == id);
            }
        }

        public RequestPromotion? Create(RequestPromotion? request)
        {
            using (var context = new JewelryProductionContext())
            {
                request.Id = Guid.NewGuid();

                request.CreatedDate = DateTime.Now;
                request.UpdatedDate = DateTime.Now;
                request.Status = "PENDING";
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

