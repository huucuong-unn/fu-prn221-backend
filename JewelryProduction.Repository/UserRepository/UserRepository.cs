using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO userDAO;

        public UserRepository() {
        if (userDAO == null)
            {
                userDAO = new UserDAO();
            }
        }

        public User Create(User user)
        {
            return userDAO.Create(user);
        }

        public bool ChangeStatus(Guid id)
        {
            return userDAO.ChangeStatus(id);
        }

        public User GetUserById(Guid id)
        {
            return userDAO.GetUserById(id);
        }

        public List<User> GetUsers(FilterModel filterModel)
        {
            return userDAO.GetUsers(filterModel);
        }

        public bool Update(Guid id, User user)
        {
            return userDAO.Update(id, user);
        }

        public int TotalItem()
        {
            return userDAO.TotalItem();
        }
    }
}
