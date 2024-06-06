using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.DAO
{
    public class CounterDAO
    {
        public CounterDAO() { }

        public List<Counter> GetCounters(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Counters
                    .Where(c => c.Status == "ACTIVE")
                    .OrderByDescending(c => c.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public Counter? GetCounterById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Counters.FirstOrDefault(c => c.Id == id);
            }
        }

        public Counter? Create(Counter? counter)
        {
            using (var context = new JewelryProductionContext())
            {
                counter.Id = Guid.NewGuid();
                counter.Status = "ACTIVE";
                context.Counters.Add(counter);
                context.SaveChanges();
                return counter;
            }
        }

        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var counter = context.Counters.FirstOrDefault(c => c.Id == id);
                if (counter == null)
                {
                    return false;
                }

                counter.Status = counter.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.Counters.Update(counter);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid id, Counter counter)
        {
            using (var context = new JewelryProductionContext())
            {
                var existingCounter = context.Counters.FirstOrDefault(c => c.Id == id);
                if (existingCounter == null)
                {
                    return false;
                }

                existingCounter.Name = counter.Name;
                existingCounter.Income = counter.Income;
                existingCounter.Status = counter.Status;
                existingCounter.CreateDate = counter.CreateDate;
                existingCounter.UpdateDate = counter.UpdateDate;
                existingCounter.CreateBy = counter.CreateBy;
                existingCounter.UpdateDate = counter.UpdateDate;

                context.Counters.Update(existingCounter);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalCounter()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Counters.Count();
            }
        }
    }
}
