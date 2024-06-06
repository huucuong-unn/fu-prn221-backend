using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.WarrantyRepository
{
    public class WarrantyRepository : IWarrantyRepository
    {
        private readonly WarrantyDAO warrantyDAO;

        public WarrantyRepository()
        {
            if (warrantyDAO == null)
            {
                warrantyDAO = new WarrantyDAO();
            }
        }

        public Warranty Create(Warranty warranty)
        {
            return warrantyDAO.Create(warranty);
        }

        public bool ChangeStatus(Guid id)
        {
            return warrantyDAO.ChangeStatus(id);
        }


        public Warranty GetWarrantyById(Guid id)
        {
            return warrantyDAO.GetWarrantyById(id);
        }

        public List<Warranty> GetWarranties(FilterModel filterModel)
        {
            return warrantyDAO.GetWarranties(filterModel);
        }

        public bool Update(Guid id, Warranty warranty)
        {
            return warrantyDAO.Update(id, warranty);
        }

        public int TotalCounter()
        {
            return warrantyDAO.TotalCounter();
        }
    }
}
