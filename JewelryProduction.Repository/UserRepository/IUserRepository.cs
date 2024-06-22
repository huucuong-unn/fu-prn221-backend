using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.UserRepository
{
    public interface IUserRepository
    {
        public List<User> GetUsers(FilterModel filterModel);

        public User GetUserById(Guid id);

        public User Create(User user);

        public bool Update(Guid id, User user);

        public bool ChangeStatus(Guid id);

        public int TotalItem();

        public User GetByEmail(string email);
    }
}
