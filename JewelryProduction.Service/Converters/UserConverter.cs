using JewelryProduction.Service.Response.User;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryProduction.Service.Request.User;

namespace JewelryProduction.Service.Converters
{
    public class UserConverter
    {
        public static GetUsersReponse toDto(User user)
        {
            GetUsersReponse getUsersReponse = new GetUsersReponse();
            getUsersReponse.Id = user.Id;
            getUsersReponse.Name = user.Name;
            getUsersReponse.Password = user.Password;
            getUsersReponse.Email = user.Email;
            getUsersReponse.Role = user.Role;
            getUsersReponse.Income = user.Income;
            getUsersReponse.CreatedDate = (DateTime) user.CreatedDate;
            getUsersReponse.UpdatedDate = (DateTime) user.UpdatedDate;
            getUsersReponse.CreateBy = user.CreateBy;
            getUsersReponse.UpdateBy = user.UpdateBy;
            getUsersReponse.Status = user.Status;
            return getUsersReponse;
        }

        public static User toEntityForCreate(CreateUserRequest createUserRequest)
        {
            User user = new User();
            user.Name = createUserRequest.Name;
            user.Password = createUserRequest.Password;
            user.Email = createUserRequest.Email;
            user.Role = createUserRequest.Role;
            user.Income = createUserRequest.Income;
            user.CreatedDate = (DateTime)createUserRequest.CreatedDate;
            user.UpdatedDate = (DateTime)createUserRequest.UpdatedDate;
            user.CreateBy = createUserRequest.CreateBy;
            user.UpdateBy = createUserRequest.UpdateBy;
            return user;
        }

        public static User toEntityForUpdate(UpdateUserRequest updateUserRequest)
        {
            User user = new User();
            user.Name = updateUserRequest.Name;
            user.Password = updateUserRequest.Password;
            user.Email = updateUserRequest.Email;
            user.Role = updateUserRequest.Role;
            user.Income = updateUserRequest.Income;
            user.Status = updateUserRequest.Status;
            user.CreatedDate = (DateTime)updateUserRequest.CreatedDate;
            user.UpdatedDate = (DateTime)updateUserRequest.UpdatedDate;
            user.CreateBy = updateUserRequest.CreateBy;
            user.UpdateBy = updateUserRequest.UpdateBy;
            return user;
        }
    }
}
