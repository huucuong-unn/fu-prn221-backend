using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.PromotionRepository
{
    public interface IPromotionRepository
    {
        public List<Promotion> GetPromotions(FilterModel filterModel);


        public Promotion GetPromotionById(Guid id);


        public Promotion Create(Promotion promotion);


        public bool ChangeStatus(Guid id);

        public List<Promotion> GetPromotionsForAdmin(string? promotionName, string? status, DateOnly? startDate, DateOnly? endDate, int page, int limit);

        public bool Update(Guid id, Promotion promotion);


        public int TotalCounter();

        public Promotion GetPromotionStatusTrue();
    }
}
