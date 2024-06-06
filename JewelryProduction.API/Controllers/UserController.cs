using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Constant;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.User;
using JewelryProduction.Service.Service.Account;
using Microsoft.AspNetCore.Mvc;

namespace JewelryProduction.API.Controllers
{
    [ApiController]
    public class UserController
    {
        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiEndPointConstant.User.GET_USER)]
        public PagingModel<GetUsersReponse> GetAll(int page, int size)
        {
            FilterModel filterModel = new FilterModel();
            filterModel.PageSize = size;
            filterModel.PageIndex = page;
            return _accountService.GetAll(filterModel);
        }

        [HttpGet(ApiEndPointConstant.User.GET_USER_BY_ID + "{id}")]
        public GetUsersReponse GetById(Guid id)
        {
            return _accountService.GetById(id);
        }

        [HttpPost(ApiEndPointConstant.User.CREATE_USER)]
        public GetUsersReponse Create(CreateUserRequest createUserRequest)
        {
            return _accountService.Create(createUserRequest);
        }

        [HttpPut(ApiEndPointConstant.User.UPDATE_USER + "{id}")]
        public bool Update(Guid id, UpdateUserRequest updateUserRequest)
        {
            return _accountService.Update(id, updateUserRequest);
        }

        [HttpDelete(ApiEndPointConstant.User.CHANGE_STATUS_USER + "{id}")]
        public bool ChangeStatus(Guid id)
        {
            return _accountService.ChangeStatus(id);
        }
    }
}
