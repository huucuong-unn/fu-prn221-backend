using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.DAO
{
    public class OrderItemDAO
    {
        public OrderItemDAO() { }

        public List<OrderItem> GetOrderItems(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.OrderItems
                    .Where(u => u.Status == "ACTIVE")
                    .OrderByDescending(u => u.CreatedDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public OrderItem GetOrderItemById(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var orderitem = context.OrderItems.FirstOrDefault(u => u.Id.Equals(id));
            return orderitem;
        }

        public OrderItem Create(OrderItem orderitem)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            orderitem.Id = Guid.NewGuid();
            orderitem.Status = "ACTIVE";
            context.Add(orderitem);
            context.SaveChanges();
            return orderitem;
        }

        public bool ChangeStatus(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var orderitemById = context.OrderItems.FirstOrDefault(u => u.Id.Equals(id));
            if (orderitemById == null)
            {
                return false;
            }

            orderitemById.Id = id;

            if (orderitemById.Status.Equals("Active"))
            {
                orderitemById.Status = "Inactive";
            }
            else
            {
                orderitemById.Status = "Active";
            }

            context.OrderItems.Update(orderitemById);
            context.SaveChanges();
            return true;
        }

        public bool Update(Guid id, OrderItem orderitem)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var orderitemById = context.OrderItems.FirstOrDefault(u => u.Id.Equals(id));
            if (orderitemById == null)
            {
                return false;
            }

            orderitemById.Status = orderitem.Status;

            context.OrderItems.Update(orderitemById);
            context.SaveChanges();
            return true;
        }

        public int TotalItem()
        {
            JewelryProductionContext context = new JewelryProductionContext();
            return context.OrderItems.Count();
        }
    }
}