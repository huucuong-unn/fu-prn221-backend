using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Response.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Converters
{
    public class CustomerConverter
    {
        public static GetCustomerResponse toDto(Customer customer)
        {
            GetCustomerResponse response = new GetCustomerResponse();
            response.Id = customer.Id;
            response.Name = customer.Name;
            response.Phone = customer.Phone;
            response.Description = customer.Description;
            response.Point = (int) customer.Point;
            response.Status = customer.Status;
            response.CreateDate = (DateTime) customer.CreateDate;
            response.UpdateDate = (DateTime) customer.UpdateDate;
            response.CreateBy = customer.CreateBy;
            response.UpdateBy = customer.UpdateBy;

            return response;
        }

        public static Customer toEntityForCreate(BaseCustomerRequest createCustomerRequest)
        {
            Customer customer = new Customer();
            customer.Name = createCustomerRequest.Name;
            customer.Phone = customer.Phone;
            customer.Description = createCustomerRequest.Description;
            customer.Point = createCustomerRequest.Point;
            customer.CreateDate = (DateTime) createCustomerRequest.CreateDate;
            customer.UpdateDate = (DateTime) createCustomerRequest.UpdateDate;
            customer.CreateBy = createCustomerRequest.CreateBy;
            customer.UpdateBy = createCustomerRequest.UpdateBy;

            return customer;
        }

        public static Customer toEntityForUpdate(BaseCustomerRequest updateCustomerRequest)
        {
            Customer customer = new Customer();
            customer.Name = updateCustomerRequest.Name;
            customer.Phone = updateCustomerRequest.Phone;
            customer.Description = updateCustomerRequest.Description;
            customer.Point = updateCustomerRequest.Point;
            customer.Status = updateCustomerRequest.Status;
            customer.CreateDate = (DateTime)updateCustomerRequest.CreateDate;
            customer.UpdateDate = (DateTime)updateCustomerRequest.UpdateDate;
            customer.CreateBy = updateCustomerRequest.CreateBy;
            customer.UpdateBy = updateCustomerRequest.UpdateBy;

            return customer;
        }
    }
}
