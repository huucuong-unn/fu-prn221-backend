using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryProduction.Repository.UserRepository;
using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.User;

namespace JewelryProduction.Service.Service.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;

        public AccountService()
        {
            if (userRepository == null)
            {
                userRepository = new UserRepository();
            }
        }

        public GetUsersReponse Create(CreateUserRequest createUserRequest)
        {
            User user = UserConverter.toEntityForCreate(createUserRequest);

            User newUser = userRepository.Create(user);

            return UserConverter.toDto(newUser);
        }

        public bool ChangeStatus(Guid id)
        {
            return userRepository.ChangeStatus(id);
        }

        public GetUsersReponse GetById(Guid id)
        {
            User user = userRepository.GetUserById(id);
            return UserConverter.toDto(user);
        }

        public PagingModel<GetUsersReponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetUsersReponse> result = new PagingModel<GetUsersReponse>();
            result.Page = filterModel.PageIndex;
            List<User> users = userRepository.GetUsers(filterModel);
            List<GetUsersReponse> getUsersReponses = users.Select(user =>
            {
                return UserConverter.toDto(user);
            }).ToList();

            result.ListResult = getUsersReponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalItem()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public int TotalItem()
        {
            return userRepository.TotalItem();
        }

        public bool Update(Guid id, UpdateUserRequest updateUserRequest)
        {
            User user = UserConverter.toEntityForUpdate(updateUserRequest);
            return userRepository.Update(id, user);
        }

    }
}
