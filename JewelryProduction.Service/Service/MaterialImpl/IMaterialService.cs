using JewelryProduction.Service.Request.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.MaterialImpl
{
    public interface IMaterialService
    {
        public bool UpdateByName(BaseMaterialRequest request);
    }
}
