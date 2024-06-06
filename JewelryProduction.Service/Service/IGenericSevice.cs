using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service
{
    public interface IGenericSevice<T>
    {
        public PagingModel<T> GetAll(FilterModel filterModel);

        public T GetById(Guid id);

        public bool ChangeStatus(Guid id);

        public int TotalItem();
    }
}
