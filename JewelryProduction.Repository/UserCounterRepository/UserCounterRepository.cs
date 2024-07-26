using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;

namespace JewelryProduction.Repository.UserCounterRepository
{
    public class UserCounterRepository : IUserCounterRepository
    {
        private readonly UserCounterDAO userCounterDAO;

        public UserCounterRepository()
        {
            if (userCounterDAO == null)
            {
                userCounterDAO = new UserCounterDAO();
            }
        }

        public List<UserCounter> GetUserCounterByCounterId(Guid counterId)
        {
            return userCounterDAO.GetUserCounterByCounterId(counterId);
        }

        public UserCounter Create(UserCounter userCounter)
        { 
            return userCounterDAO.Create(userCounter);
        }

        public bool ChangeStatus(Guid staffId, Guid counterId)
        {
            return userCounterDAO.ChangeStatus(staffId, counterId);
        }

        public UserCounter GetUserCounterById(Guid staffId, Guid counterId)
        {
            return userCounterDAO.GetUserCounterById(staffId, counterId);
        }

        public List<UserCounter> GetUserCounters(FilterModel filterModel)
        {
            return userCounterDAO.GetUserCounters(filterModel);
        }

        public bool Update(Guid staffId, Guid counterId, UserCounter userCounter)
        {
            return userCounterDAO.Update(staffId, counterId, userCounter);
        }

        public int TotalUserCounter()
        {
            return userCounterDAO.TotalUserCounter();
        }

        public Guid GetCounterIdByStaffId(Guid staffId)
        {
            return userCounterDAO.GetCounterIdByStaffId(staffId);
        }
    }
}