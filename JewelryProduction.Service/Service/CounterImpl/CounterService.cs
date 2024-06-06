using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CounterRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Counter;
using JewelryProduction.Service.Response.Counter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.Service.Service.Counter
{
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository counterRepository;

        public CounterService()
        {
            if (counterRepository == null)
            {
                counterRepository = new CounterRepository();
            }
        }

        public GetCounterResponse Create(GetCounterRequest createCounterRequest)
        {
            BusinessObject.Models.Counter counter = CounterConverter.toEntityForCreate(createCounterRequest);
            BusinessObject.Models.Counter newCounter = counterRepository.Create(counter);
            return CounterConverter.toDto(newCounter);
        }

        public bool ChangeStatus(Guid id)
        {
            return counterRepository.ChangeStatus(id);
        }

        public GetCounterResponse GetById(Guid id)
        {
            BusinessObject.Models.Counter counter = counterRepository.GetCounterById(id);
            return CounterConverter.toDto(counter);
        }

        public PagingModel<GetCounterResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetCounterResponse> result = new PagingModel<GetCounterResponse>();
            result.Page = filterModel.PageIndex;
            List<BusinessObject.Models.Counter> counters = counterRepository.GetCounters(filterModel);
            List<GetCounterResponse> getCounterResponses = counters.Select(counter =>
            {
                return CounterConverter.toDto(counter);
            }).ToList();

            result.ListResult = getCounterResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalCounter()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public int TotalCounter()
        {
            return counterRepository.TotalCounter();
        }

        public bool Update(Guid id, GetCounterRequest updateCounterRequest)
        {
            BusinessObject.Models.Counter counter = CounterConverter.toEntityForUpdate(updateCounterRequest);
            return counterRepository.Update(id, counter);
        }
    }
}
