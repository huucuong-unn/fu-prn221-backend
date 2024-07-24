using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace JewelryProduction.DAO
{
    public class UserCounterDAO
    {
        public UserCounterDAO() { }

        public List<UserCounter?> GetUserCounters(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.UserCounters
                    .Where(uc => uc.Status == "ACTIVE")
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public UserCounter? GetUserCounterById(Guid staffId, Guid counterId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.UserCounters.FirstOrDefault(uc => uc.StaffId == staffId && uc.CounterId == counterId);
            }
        }
        public List<UserCounter?> GetUserCounterByCounterId( Guid counterId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.UserCounters.Where(uc =>  uc.CounterId == counterId).ToList();
            }
        }

        public UserCounter? Create(UserCounter? userCounter)
        {
            using (var context = new JewelryProductionContext())
            {
                var prevUserCounters = context.UserCounters.Where(uc => uc.StaffId == userCounter.StaffId).ToList();
                foreach (var uc in prevUserCounters)
                { 
                    if(uc.CounterId == userCounter.CounterId)
                    {
                        uc.Status = "ACTIVE";
                        Update(uc.StaffId, uc.CounterId, uc);
                        return uc;
                    }

                    uc.Status = "INACTIVE";
                    Update(uc.StaffId, uc.CounterId, uc);
                }

                userCounter.Status = "ACTIVE";
                context.UserCounters.Add(userCounter);
                context.SaveChanges();
                return userCounter;
            }
        }

        public bool ChangeStatus(Guid staffId, Guid counterId)
        {
            using (var context = new JewelryProductionContext())
            {
                var userCounter = context.UserCounters.FirstOrDefault(uc => uc.StaffId == staffId && uc.CounterId == counterId);
                if (userCounter == null)
                {
                    return false;
                }

                userCounter.Status = userCounter.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.UserCounters.Update(userCounter);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid staffId, Guid counterId, UserCounter userCounter)
        {
            using (var context = new JewelryProductionContext())
            {
                var existingUserCounter = context.UserCounters.FirstOrDefault(uc => uc.StaffId == staffId && uc.CounterId == counterId);
                if (existingUserCounter == null)
                {
                    return false;
                }

                existingUserCounter.Status = userCounter.Status;
                context.UserCounters.Update(existingUserCounter);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalUserCounter()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.UserCounters.Count();
            }
        }

        public Guid GetCounterIdByStaffId(Guid staffId)
        {
            using (var context = new JewelryProductionContext())
            {
                var counterUser = context.UserCounters.FirstOrDefault(uc => uc.StaffId == staffId && uc.Status == "ACTIVE");
                if (counterUser == null) return Guid.Empty;
                return counterUser.CounterId;
            }
        }
        
    }
}
