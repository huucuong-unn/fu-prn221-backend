using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Service.Service.RequestPromotionImpl
{
    public interface IRequestPromotionImpl
    {
        public List<RequestPromotion> GetRequestPromotions();
        public RequestPromotion? GetRequestPromotionById(Guid id);
        public RequestPromotion? Create(RequestPromotion? request);
        public void ChangeStatus(Guid id, string status);

    }
}
