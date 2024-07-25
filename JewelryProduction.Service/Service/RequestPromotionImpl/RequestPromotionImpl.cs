using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Repository.RequestPromotionRepository;
using JewelryProduction.Repository.RequestRepository;

namespace JewelryProduction.Service.Service.RequestPromotionImpl
{
    public class RequestPromotionImpl : IRequestPromotionImpl
    {
        private readonly IRequestPromotionRepository requestPromotionRepository;

        public RequestPromotionImpl()
        {
            if (requestPromotionRepository == null)
            {
                requestPromotionRepository = new RequestPromotionRepository();
            }
        }
        public void ChangeStatus(Guid id, string status)
        {
            requestPromotionRepository.ChangeStatus(id, status);
        }

        public RequestPromotion? Create(RequestPromotion? request)
        {
            return requestPromotionRepository?.Create(request);
        }

        public RequestPromotion? GetRequestPromotionById(Guid id)
        {
            return requestPromotionRepository.GetRequestById(id);
        }

        public List<RequestPromotion> GetRequestPromotions()
        {
            return requestPromotionRepository.GetRequests();
        }
    }
}
