using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.MaterialRepository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly MaterialDAO materialDAO;

        public MaterialRepository()
        {
            if (materialDAO == null)
            {
                materialDAO = new MaterialDAO();
            }
        }

        public Material GetById(Guid id)
        {
            return materialDAO.GetById(id);
        }

        public bool UpdateByName(string name, Material material)
        {
            return materialDAO.UpdateByName(name, material);
        }

        public List<Material> GetMaterialWithoutPaging() { return materialDAO.GetMaterialWithoutPaging();}

        public Material GetByName(string name)
        {
            return materialDAO.GetByName(name);
        }
    }
}
