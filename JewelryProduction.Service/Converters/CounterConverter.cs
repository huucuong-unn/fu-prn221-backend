using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Response.Counter;
using System;

namespace JewelryProduction.Service.Converters
{
    public class CounterConverter
    {
        public static GetCounterResponse toDto(Counter counter)
        {
            GetCounterResponse getCounterResponse = new GetCounterResponse();
            getCounterResponse.Id = counter.Id;
            getCounterResponse.Name = counter.Name;
            getCounterResponse.Income = (decimal)counter.Income;
            getCounterResponse.Status = counter.Status;
            getCounterResponse.CreateDate = (DateTime)counter.CreateDate;
            getCounterResponse.CreateBy = counter.CreateBy;
            getCounterResponse.UpdateDate = (DateTime)counter.UpdateDate;
            getCounterResponse.UpdateBy = counter.UpdateBy;
            return getCounterResponse;
        }

        public static Counter toEntityForCreate(GetCounterRequest createCounterRequest)
        {
            Counter counter = new Counter();
            counter.Name = createCounterRequest.Name;
            counter.Income = createCounterRequest.Income;
            counter.Status = "ACTIVE";
            counter.CreateDate = DateTime.Now;
            counter.CreateBy = createCounterRequest.CreateBy;
            counter.UpdateDate = DateTime.Now;
            counter.UpdateBy = createCounterRequest.UpdateBy;
            return counter;
        }

        public static Counter toEntityForUpdate(GetCounterRequest updateCounterRequest)
        {
            Counter counter = new Counter();
            counter.Name = updateCounterRequest.Name;
            counter.Income = updateCounterRequest.Income;
            counter.Status = updateCounterRequest.Status;
            counter.CreateDate = updateCounterRequest.CreateDate;
            counter.CreateBy = updateCounterRequest.CreateBy;
            counter.UpdateDate = DateTime.Now;
            counter.UpdateBy = updateCounterRequest.UpdateBy;
            return counter;
        }
    }
}
