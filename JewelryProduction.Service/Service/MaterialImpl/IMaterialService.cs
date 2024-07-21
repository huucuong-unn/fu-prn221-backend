using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Material;
using JewelryProduction.Service.Response.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.MaterialImpl
{
    public interface IMaterialService : IGenericSevice<GetMaterialResponse>
    {
        public bool UpdateByName(BaseMaterialRequest request);

        public List<GetMaterialResponse> GetMaterialWithoutPaging();

        public Material GetByName(string name);

    }
}
