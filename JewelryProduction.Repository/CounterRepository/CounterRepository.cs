using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;

namespace JewelryProduction.Repository.CounterRepository
{
    public class CounterRepository : ICounterRepository
    {
        private readonly CounterDAO counterDAO;

        public CounterRepository()
        {
            if (counterDAO == null)
            {
                counterDAO = new CounterDAO();
            }
        }

        public Counter Create(Counter counter)
        {
            return counterDAO.Create(counter);
        }

        public bool ChangeStatus(Guid id)
        {
            return counterDAO.ChangeStatus(id);
        }
        

        public Counter GetCounterById(Guid id)
        {
            return counterDAO.GetCounterById(id);
        }

        public List<Counter> GetCounters(FilterModel filterModel)
        {
            return counterDAO.GetCounters(filterModel);
        }

        public bool Update(Guid id, Counter counter)
        {
            return counterDAO.Update(id, counter);
        }

        public int TotalCounter()
        {
            return counterDAO.TotalCounter();
        }

        public List<Counter> GetCountersWithoutPaging()
        {
            return counterDAO.GetCountersWithoutPaging();
        }
    }
}