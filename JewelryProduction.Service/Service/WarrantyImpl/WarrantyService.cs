using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CounterRepository;
using JewelryProduction.Repository.WarrantyRepository;
using JewelryProduction.Service.Converters;
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
    public class WarrantyService : IWarrantyService
    {
        private readonly IWarrantyRepository warrantyRepository;

        public WarrantyService()
        {
            if (warrantyRepository == null)
            {
                warrantyRepository = new WarrantyRepository();
            }
        }

        public GetWarrantyResponse Create(BaseWarrantyRequest createWarrantyRequest)
        {
            BusinessObject.Models.Warranty warranty = WarrantyConverter.toEntityForCreate(createWarrantyRequest);
            BusinessObject.Models.Warranty newWarranty = warrantyRepository.Create(warranty);
            return WarrantyConverter.toDto(newWarranty);
        }

        public bool ChangeStatus(Guid id)
        {
            return warrantyRepository.ChangeStatus(id);
        }

        public GetWarrantyResponse GetById(Guid id)
        {
            BusinessObject.Models.Warranty warranty = warrantyRepository.GetWarrantyById(id);
            return WarrantyConverter.toDto(warranty);
        }

        public PagingModel<GetWarrantyResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetWarrantyResponse> result = new PagingModel<GetWarrantyResponse>();
            result.Page = filterModel.PageIndex;
            List<BusinessObject.Models.Warranty> warranties = warrantyRepository.GetWarranties(filterModel);
            List<GetWarrantyResponse> getWarrantyResponses = warranties.Select(warranties =>
            {
                return WarrantyConverter.toDto(warranties);
            }).ToList();

            result.ListResult = getWarrantyResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalCounter()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public int TotalCounter()
        {
            return warrantyRepository.TotalCounter();
        }

        public bool Update(Guid id, BaseWarrantyRequest updateWarrantyRequest)
        {
            BusinessObject.Models.Warranty warranty = WarrantyConverter.toEntityForUpdate(updateWarrantyRequest);
            return warrantyRepository.Update(id, warranty);
        }
    }

}



