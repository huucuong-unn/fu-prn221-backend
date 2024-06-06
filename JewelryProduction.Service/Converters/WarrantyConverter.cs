using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Request.Warranty;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Warranty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Converters
{
    public class WarrantyConverter
    {
        public static GetWarrantyResponse toDto(Warranty warranty)
        {
            GetWarrantyResponse getWarrantyResponse = new GetWarrantyResponse();
            getWarrantyResponse.StartDate = (DateOnly)warranty.StartDate;
            getWarrantyResponse.EndDate = (DateOnly)warranty.EndDate;
            getWarrantyResponse.Description = warranty.Description;
            getWarrantyResponse.Status = warranty.Status;
            getWarrantyResponse.CreateDate = (DateTime)warranty.CreateDate;
            getWarrantyResponse.CreateBy = warranty.CreateBy;
            getWarrantyResponse.UpdateDate = (DateTime)warranty.UpdateDate;
            getWarrantyResponse.UpdateBy = warranty.UpdateBy;
            return getWarrantyResponse;
        }

        public static Warranty toEntityForCreate(BaseWarrantyRequest createWarrantyRequest)
        {
            Warranty warranty = new Warranty();
            warranty.StartDate = createWarrantyRequest.StartDate;
            warranty.EndDate = createWarrantyRequest.EndDate;
            warranty.Status = "ACTIVE";
            warranty.CreateDate = DateTime.Now;
            warranty.CreateBy = createWarrantyRequest.CreateBy;
            warranty.UpdateDate = DateTime.Now;
            warranty.UpdateBy = createWarrantyRequest.CreateBy;
            return warranty;
        }

        public static Warranty toEntityForUpdate(BaseWarrantyRequest updateWarrantyRequest)
        {
            Warranty warranty = new Warranty();
            warranty.StartDate = updateWarrantyRequest.StartDate;
            warranty.EndDate = updateWarrantyRequest.EndDate;
            warranty.Status = "ACTIVE";
            warranty.CreateDate = DateTime.Now;
            warranty.CreateBy = updateWarrantyRequest.CreateBy;
            warranty.UpdateDate = DateTime.Now;
            warranty.UpdateBy = updateWarrantyRequest.CreateBy;
            return warranty;
        }
    }
}

