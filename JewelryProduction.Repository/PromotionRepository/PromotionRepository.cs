using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;

namespace JewelryProduction.Repository.PromotionRepository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionDAO promotionDAO;

        public PromotionRepository()
        {
            if (promotionDAO == null)
            {
                promotionDAO = new PromotionDAO();
            }
        }

        public Promotion Create(Promotion promotion)
        {
            return promotionDAO.Create(promotion);
        }

        public bool ChangeStatus(Guid id)
        {
            return promotionDAO.ChangeStatus(id);
        }

        public Promotion GetPromotionById(Guid id)
        {
            return promotionDAO.GetPromotionById(id);
        }

        public List<Promotion> GetPromotions(FilterModel filterModel)
        {
            return promotionDAO.GetPromotions(filterModel);
        }

        public bool Update(Guid id, Promotion promotion)
        {
            return promotionDAO.Update(id, promotion);
        }

        public int TotalCounter()
        {
            return promotionDAO.TotalCounter();
        }

        public List<Promotion> GetPromotionsForAdmin(string? promotionName, string? status, DateOnly? startDate, DateOnly? endDate, int page, int limit)
        {
            return promotionDAO.GetPromotionsForAdmin(promotionName, status, startDate, endDate, page, limit);
        }

        public Promotion GetPromotionStatusTrue()
        {
            return promotionDAO.FindByStatusTrue(); 
        }
    }
}

