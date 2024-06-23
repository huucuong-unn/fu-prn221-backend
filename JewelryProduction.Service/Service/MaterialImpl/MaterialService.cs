using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.MaterialRepository;
using JewelryProduction.Service.Request.Material;
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
