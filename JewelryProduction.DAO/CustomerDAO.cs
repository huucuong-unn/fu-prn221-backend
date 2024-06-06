using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.DAO
{
    public class CustomerDAO
    {
        public CustomerDAO() { }

        public List<Customer> GetCustomers(FilterModel filterModel) {
            using (var context = new JewelryProductionContext())
            {
                return context.Customers
                    .Where(u => u.Status == "ACTIVE")
                    .OrderByDescending(u => u.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public Customer GetById(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var customer = context.Customers.FirstOrDefault(u => u.Id.Equals(id));
            return customer;
        }

        public Customer Create(Customer customer)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            customer.Id = Guid.NewGuid();
            customer.Status = "ACTIVE";
            context.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public bool ChangeStatus(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var customerById = context.Customers.FirstOrDefault(u => u.Id.Equals(id));
            if (customerById == null)
            {
                return false;
            }

            customerById.Id = id;
            if (customerById.Status.Equals("Active"))
            {
                customerById.Status = "Inactive";
            } else
            {
                customerById.Status = "Active";
            }

            context.Customers.Update(customerById);
            context.SaveChanges();
            return true;
        }

        public bool Update(Guid id, Customer customer)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var customerById = context.Customers.FirstOrDefault(u => u.Id.Equals(id));
            if (customerById == null)
            {
                return false;
            }
            customerById.Id = id;
            customerById.Name = customer.Name;
            customerById.Phone = customer.Phone;
            customerById.Description = customer.Description;
            customerById.Point = customer.Point;
            customerById.Status = customer.Status;
            customerById.CreateDate = customer.CreateDate;
            customerById.UpdateDate = customer.UpdateDate;
            customerById.CreateBy = customer.CreateBy;
            customerById.UpdateBy = customer.UpdateBy;

            context.Customers.Update(customerById);
            context.SaveChanges();
            return true;
        }

        public int TotalItem()
        {
            JewelryProductionContext context = new JewelryProductionContext();
            return context.Customers.Count();
        }
    }
}
