using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.DAO
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        //Get material by name
        public Material GetByName(string name)
        {
            using (var context = new JewelryProductionContext())
            {
                var material = context.Materials.FirstOrDefault(m => m.Name.Equals(name));
                return material;
            }
        }

        //get material without paging
        public List<Material> GetMaterialWithoutPaging()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Materials.ToList();
            }
        }

        //get material by id
        public Material GetById(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var material = context.Materials.FirstOrDefault(m => m.Id.Equals(id));
            return material;
        }

        //update material by name
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
