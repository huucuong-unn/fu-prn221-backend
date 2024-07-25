using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using JewelryProduction.Repository.RequestRepository;

namespace JewelryProduction.Repository.RequestPromotionRepository
{
    public class RequestPromotionRepository : IRequestPromotionRepository
    {
        private readonly RequestPromotionDAO requestDAO;

        public void ChangeStatus(Guid id, string status)
        {
            requestDAO.ChangeStatus(id, status);
        }

        public RequestPromotion? Create(RequestPromotion? request)
        {
            return requestDAO.Create(request);
        }

        public RequestPromotion? GetRequestPromotionById(Guid id)
        {
            return requestDAO.GetRequestPromotionById(id);
        }

        public List<RequestPromotion> GetRequestPromotions()
        {
            return requestDAO.GetRequestPromotions();
        }
    }
}
