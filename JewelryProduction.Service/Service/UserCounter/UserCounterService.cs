using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.UserCounterRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.UserCounter;
using JewelryProduction.Service.Response.UserCounter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.Service.Service.UserCounter
{
    public class UserCounterService : IUserCounterService
    {
        private readonly IUserCounterRepository _userCounterRepository;

        public UserCounterService()
        {
            _userCounterRepository = new UserCounterRepository();
        }

        public GetUserCounterResponse Create(GetUserCounterRequest request)
        {
            var userCounter = UserCounterConverter.ToEntity(request);
            var createdUserCounter = _userCounterRepository.Create(userCounter);
            return UserCounterConverter.ToDto(createdUserCounter);
        }

        public bool ChangeStatus(Guid staffId, Guid counterId)
        {
            return _userCounterRepository.ChangeStatus(staffId, counterId);
        }

        public GetUserCounterResponse GetById(Guid staffId, Guid counterId)
        {
            var userCounter = _userCounterRepository.GetUserCounterById(staffId, counterId);
            return UserCounterConverter.ToDto(userCounter);
        }

        public  List<GetUserCounterResponse> GetByCounterId(Guid counterId)
        {
            List<BusinessObject.Models.UserCounter> userCounters = _userCounterRepository.GetUserCounterByCounterId(counterId);

            List<GetUserCounterResponse> getCounterRequests = userCounters.Select(usercounter =>
            {
                return UserCounterConverter.ToDto(usercounter);
            }).ToList();
            return getCounterRequests;
        }

        public PagingModel<GetUserCounterResponse> GetAll(FilterModel filterModel)
        {
            var pagingModel = new PagingModel<GetUserCounterResponse>();
            pagingModel.Page = filterModel.PageIndex;
            var userCounters = _userCounterRepository.GetUserCounters(filterModel);
            var listResult = userCounters.Select(UserCounterConverter.ToDto).ToList();

            pagingModel.ListResult = listResult;
            pagingModel.TotalPages = (int)Math.Ceiling((double)_userCounterRepository.TotalUserCounter() / filterModel.PageSize);
            pagingModel.Size = filterModel.PageSize;
            return pagingModel;
        }

        public int TotalUserCounter()
        {
            return _userCounterRepository.TotalUserCounter();
        }

        public bool Update(Guid staffId, Guid counterId, GetUserCounterRequest request)
        {
            var existingUserCounter = _userCounterRepository.GetUserCounterById(staffId, counterId);
            if (existingUserCounter == null)
            {
                return false;
            }

            UserCounterConverter.UpdateEntity(request, existingUserCounter);
            return _userCounterRepository.Update(staffId, counterId, existingUserCounter);
        }
    }
}
