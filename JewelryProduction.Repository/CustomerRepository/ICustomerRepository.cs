using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAll(FilterModel filterModel);

        public Customer GetById(Guid id);

        public Customer Create(Customer customer);

        public bool Update(Guid id, Customer customer);

        public bool ChangeStatus(Guid id);

        public int TotalItem();
    }
}
