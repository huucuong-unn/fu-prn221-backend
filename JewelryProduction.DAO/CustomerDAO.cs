using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.DAO
{
    public class CustomerDAO
    {
        public CustomerDAO() { }

        //Get customers
        public List<Customer> GetCustomers(FilterModel filterModel)
        {
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

        //get by id
        public Customer GetById(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var customer = context.Customers.FirstOrDefault(u => u.Id.Equals(id));
            return customer;
        }

        //create customer
        public Customer Create(Customer customer)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            customer.Id = Guid.NewGuid();
            customer.Status = "ACTIVE";
            context.Add(customer);
            context.SaveChanges();
            return customer;
        }

        //change status
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
            }
            else
            {
                customerById.Status = "Active";
            }

            context.Customers.Update(customerById);
            context.SaveChanges();
            return true;
        }

        //Update customer
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

        //count total item
        public int TotalItem()
        {
            JewelryProductionContext context = new JewelryProductionContext();
            return context.Customers.Count();
        }

        //get customer by phone
        public Customer GetByPhone(string phone)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var customer = context.Customers.FirstOrDefault(u => u.Phone.Equals(phone));
            if (customer == null) { return null; }
            return customer;

        }

        //get top 5 customer with most orders
        public List<Customer> GetTop5CustomersWithMostOrders()
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var top5CustomerIds = context.Orders
                .Where(o => o.Status == "ACTIVE")
                .GroupBy(o => o.CustomerId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();

            List<Customer> customers = context.Customers
            .Where(c => top5CustomerIds.Contains(c.Id))
            .ToList();

            return customers;
        }
    }
}
