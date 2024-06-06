using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Promotion;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Promotion;
using JewelryProduction.Service.Response.Warranty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.PromotionImpl
{
    public interface IPromotionService
    {
        GetPromotionResponse Create(BasePromotionRequest createPromotionRequest);

        bool ChangeStatus(Guid id);

        GetPromotionResponse GetById(Guid id);

        PagingModel<GetPromotionResponse> GetAll(FilterModel filterModel);

        int TotalCounter();

        bool Update(Guid id, BasePromotionRequest updatePromotionRequest);
    }
}
