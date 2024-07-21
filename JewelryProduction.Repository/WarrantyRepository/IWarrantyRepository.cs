using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.WarrantyRepository
{
    public interface IWarrantyRepository
    {
        public List<Warranty> GetWarranties(FilterModel filterModel);


        public Warranty GetWarrantyById(Guid id);


        public Warranty Create(Warranty warranty);


        public bool ChangeStatus(Guid id);


        public bool Update(Guid id, Warranty warranty);


        public int TotalCounter();

        public bool Delete(Guid id);

}
}
