using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.RequestRepository
{
    public interface IRequestPromotionRepository
    {
        public List<RequestPromotion> GetRequestPromotions();

        public RequestPromotion? GetRequestPromotionById(Guid id);

        public RequestPromotion? Create(RequestPromotion? request);

        public void ChangeStatus(Guid id, string status);
    }
}
