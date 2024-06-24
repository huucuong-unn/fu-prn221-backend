using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Response.Customer;
using JewelryProduction.Service.Response.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Converters
{
    public class MaterialConverter
    {
        public static GetMaterialResponse toDto(Material material)
        {
            GetMaterialResponse response = new GetMaterialResponse();
            response.Id = material.Id;
            response.Name = material.Name;
            response.BuyingPrice = material.BuyingPrice;
            response.SalePrice = (decimal)material.SalePrice;
            response.CreateDate = (DateTime)material.CreateDate;
            response.UpdateDate = (DateTime)material.UpdateDate;

            return response;
        }
    }
}
