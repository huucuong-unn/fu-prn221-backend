using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.MaterialRepository
{
    public interface IMaterialRepository
    {
        public bool UpdateByName(string name, Material material);

        public Material GetById(Guid id);
    }
}
