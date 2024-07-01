using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.MaterialRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Material;
using JewelryProduction.Service.Response.Counter;
using JewelryProduction.Service.Response.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.MaterialImpl
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialService()
        {
            if (materialRepository == null)
            {
                materialRepository = new MaterialRepository();
            }
        }

        public bool ChangeStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        public PagingModel<GetMaterialResponse> GetAll(FilterModel filterModel)
        {
            throw new NotImplementedException();
        }

        public GetMaterialResponse GetById(Guid id)
        {
            Material material = materialRepository.GetById(id);

            return MaterialConverter.toDto(material);
        }

        public List<GetMaterialResponse> GetMaterialWithoutPaging()
        {
            List<Material> materials = materialRepository.GetMaterialWithoutPaging();

            List<GetMaterialResponse> getMaterialResponses = materials.Select(material =>
            {
                return MaterialConverter.toDto(material);
            }).ToList();

            return getMaterialResponses;
        }

        public int TotalItem()
        {
            throw new NotImplementedException();
        }

        public bool UpdateByName(BaseMaterialRequest request)
        {
            Material material = new Material();
            material.SalePrice = request.salePrice;
            material.BuyingPrice = request.buyingPrice;
            material.CreateDate = request.CreateDate;
            material.UpdateDate = request.UpdateDate;

            return materialRepository.UpdateByName(request.name, material); ;
        }
    }
}
