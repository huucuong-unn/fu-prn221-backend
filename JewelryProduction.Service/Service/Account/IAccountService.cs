using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Service.Account
{
    public interface IAccountService : IGenericSevice<GetUsersReponse>
    {

        public GetUsersReponse Create(CreateUserRequest user);

        public bool Update(Guid id, UpdateUserRequest user);

        public User GetByEmail(string email);
        
        public PagingModel<GetUsersReponse> GetStaff(FilterModel filterModel);
        
        
    }
}
