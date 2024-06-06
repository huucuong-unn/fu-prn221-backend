using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;

namespace JewelryProduction.Repository.CounterRepository
{
    public interface ICounterRepository
    {
        List<Counter> GetCounters(FilterModel filterModel);

        Counter GetCounterById(Guid id);

        Counter Create(Counter counter);

        bool Update(Guid id, Counter counter);

        bool ChangeStatus(Guid id);

        int TotalCounter();
    }
}