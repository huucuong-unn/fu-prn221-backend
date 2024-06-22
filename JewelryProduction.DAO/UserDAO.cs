using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.DAO
{
    public class UserDAO
    {
        public UserDAO() { }

        public List<User> GetUsers(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Users
                    .Where(u => u.Status == "ACTIVE")
                    .OrderByDescending(u => u.CreatedDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public User GetUserById(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var user = context.Users.FirstOrDefault(u => u.Id.Equals(id));
            return user;
        }

        public User Create(User user)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            user.Id = Guid.NewGuid();
            user.Status = "ACTIVE";
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public bool ChangeStatus(Guid id) {
            JewelryProductionContext context = new JewelryProductionContext();
            var userById = context.Users.FirstOrDefault(u => u.Id.Equals(id));
            if (userById == null)
            {
                return false;
            }

            userById.Id = id;
            
            if (userById.Status.Equals("Active"))
            {
                userById.Status = "Inactive";
            } else
            {
                userById.Status = "Active";
            }

            context.Users.Update(userById);
            context.SaveChanges();
            return true;
        }

        public bool Update(Guid id, User user) {
            JewelryProductionContext context = new JewelryProductionContext();
            var userById = context.Users.FirstOrDefault(u => u.Id.Equals(id));
            if (userById == null)
            {
                return false;
            }
            userById.Id = id;
            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Role = user.Role;
            userById.Password = user.Password;
            userById.Income = user.Income;
            userById.CreatedDate = user.CreatedDate;
            userById.UpdatedDate = user.UpdatedDate;
            userById.CreateBy = user.CreateBy;
            userById.UpdateBy = user.UpdateBy;
            userById.Status = user.Status;

            context.Users.Update(userById);
            context.SaveChanges();
            return true;
        }

        public int TotalItem()
        {
            JewelryProductionContext context = new JewelryProductionContext();
            return context.Users.Count();
        }

        public User GetByEmail(string email)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            return context.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}
