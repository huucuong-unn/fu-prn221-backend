using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.CustomerRepository;
using JewelryProduction.Repository.UserRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.CustomerImpl
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService()
        {
            if (customerRepository == null)
            {
                customerRepository = new CustomerRepository();
            }
        }

        public GetCustomerResponse Create(CreateCustomerRequest createCustomerRequest)
        {
            Customer customer = CustomerConverter.toEntityForCreate(createCustomerRequest);

            Customer newCustomer = customerRepository.Create(customer);

            return CustomerConverter.toDto(newCustomer);
        }

        public bool ChangeStatus(Guid id)
        {
            return customerRepository.ChangeStatus(id);
        }

        public PagingModel<GetCustomerResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetCustomerResponse> result = new PagingModel<GetCustomerResponse>();
            result.Page = filterModel.PageIndex;
            List<Customer> customers = customerRepository.GetAll(filterModel);
            List<GetCustomerResponse> getCustomerResponses = customers.Select(customer =>
            {
                return CustomerConverter.toDto(customer);
            }).ToList();

            result.ListResult = getCustomerResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalItem()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public GetCustomerResponse GetById(Guid id)
        {
            Customer customer = customerRepository.GetById(id);
            return CustomerConverter.toDto(customer);
        }

        public int TotalItem()
        {
            return customerRepository.TotalItem();
        }

        public bool Update(Guid id, UpdateCustomerRequest updateCustomerRequest)
        {
            Customer customer = CustomerConverter.toEntityForUpdate(updateCustomerRequest);
            return customerRepository.Update(id, customer);
        }

        public GetCustomerResponse GetByPhone(string phone)
        {
            Customer customerEntity = customerRepository.GetByPhone(phone);
            if (customerEntity == null) return null;
            GetCustomerResponse customer = CustomerConverter.toDto(customerEntity);
            return customer;
        }

    }
}
