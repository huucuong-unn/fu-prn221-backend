using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDAO customerDAO;

        public CustomerRepository()
        {
            if (customerDAO == null)
            {
                customerDAO = new CustomerDAO();
            }
        }

        public Customer Create(Customer customer)
        {
            return customerDAO.Create(customer);
        }

        public bool ChangeStatus(Guid id)
        {
            return customerDAO.ChangeStatus(id);
        }

        public List<Customer> GetAll(FilterModel filterModel)
        {
            return customerDAO.GetCustomers(filterModel);
        }

        public Customer GetById(Guid id)
        {
            return customerDAO.GetById(id);
        }

        public int TotalItem()
        {
            return customerDAO.TotalItem();
        }

        public bool Update(Guid id, Customer customer)
        {
            return customerDAO.Update(id, customer);
        }

        public Customer GetByPhone(string phone)
        {
            return customerDAO.GetByPhone(phone);
        }

        public List<Customer> GetTop5CustomersWithMostOrders()
        {
            return customerDAO.GetTop5CustomersWithMostOrders();
        }
    }
}
