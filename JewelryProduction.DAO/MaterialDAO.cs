using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.DAO
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        public Material GetByName(string name)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var material = context.Materials.FirstOrDefault(m => m.Name.Equals(name));
            return material;
        }

        public bool UpdateByName(string name, Material material)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var materialByName = GetByName(name);
            if (materialByName == null)
            {
                return false;
            }

            materialByName.SalePrice = material.SalePrice;
            materialByName.BuyingPrice = material.BuyingPrice;
            materialByName.CreateDate = material.CreateDate;
            materialByName.UpdateDate = material.UpdateDate;

            context.Materials.Update(materialByName);
            context.SaveChanges();
            return true;
        }
    }
}
