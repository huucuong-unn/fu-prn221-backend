using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;

namespace JewelryProduction.Repository.UserCounterRepository
{
    public interface IUserCounterRepository
    {
        List<UserCounter> GetUserCounters(FilterModel filterModel);

        UserCounter GetUserCounterById(Guid staffId, Guid counterId);
        
        UserCounter GetUserCounterByCounterId( Guid counterId);

        UserCounter Create(UserCounter userCounter);

        bool Update(Guid staffId, Guid counterId, UserCounter userCounter);

        bool ChangeStatus(Guid staffId, Guid counterId);

        int TotalUserCounter();

        Guid GetCounterIdByStaffId(Guid staffId);
    }
}