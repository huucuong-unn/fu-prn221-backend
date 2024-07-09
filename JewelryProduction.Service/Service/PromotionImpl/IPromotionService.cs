using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Promotions;
using JewelryProduction.Service.Response.Promotion;

namespace JewelryProduction.Service.Service.PromotionImpl
{
    public interface IPromotionService
    {
        GetPromotionResponse Create(BasePromotionRequest createPromotionRequest);

        bool ChangeStatus(Guid id);

        GetPromotionResponse GetById(Guid id);

        PagingModel<GetPromotionResponse> GetAll(FilterModel filterModel);

        PagingModel<GetPromotionResponse> GetAllForAdmin(string? promotionName, string? status, DateOnly? startDate, DateOnly? endDate, int page, int limit);

        int TotalCounter();

        bool Update(Guid id, BasePromotionRequest updatePromotionRequest);
    }
}
