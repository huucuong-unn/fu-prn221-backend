using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Customer;
using JewelryProduction.Service.Response.User;
using JewelryProduction.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.CustomerImpl
{
    public interface ICustomerService : IGenericSevice<GetCustomerResponse>
    {

        public GetCustomerResponse Create(BaseCustomerRequest createCustomerRequest);

        public bool Update(Guid id, BaseCustomerRequest updateCustomerRequest);

        public GetCustomerResponse GetByPhone(string phone);
    }
}
