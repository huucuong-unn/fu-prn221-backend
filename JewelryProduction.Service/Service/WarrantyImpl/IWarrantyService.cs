using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Warranty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.WarrantyImpl
{
    public interface IWarrantyService
    {
        GetWarrantyResponse Create(BaseWarrantyRequest createWarrantyRequest);

        bool ChangeStatus(Guid id);

        GetWarrantyResponse GetById(Guid id);

        PagingModel<GetWarrantyResponse> GetAll(FilterModel filterModel);

        int TotalCounter();

        bool Update(Guid id, BaseWarrantyRequest updateWarrantyRequest);

    }
}
