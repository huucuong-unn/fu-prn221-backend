using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.DAO
{
    public class OrderDAO
    {
        public OrderDAO() { }

        public List<Order> GetOrders(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Orders
                    .OrderByDescending(u => u.CreatedDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public Order GetById(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var order = context.Orders.FirstOrDefault(u => u.Id.Equals(id));
            return order;
        }

        public Order Create(Order order)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            order.Id = Guid.NewGuid();
            order.Status = "ACTIVE";
            context.Add(order);
            context.SaveChanges();
            return order;
        }      

        
        public bool Delete(Guid id)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var orderById = context.Orders.FirstOrDefault(u => u.Id.Equals(id));
            if (orderById == null)
            {
                return false;
            }

            orderById.Id = id;
            orderById.Status = "INACTIVE";

            context.Orders.Update(orderById);
            context.SaveChanges();
            return true;
        }

        public bool Update(Guid id, Order order)
        {
            JewelryProductionContext context = new JewelryProductionContext();
            var orderById = context.Orders.FirstOrDefault(u => u.Id.Equals(id));
            if (orderById == null)
            {
                return false;
            }
            orderById.Id = id;
            orderById.CustomerId = order.CustomerId;
            orderById.PromotionId = order.PromotionId;
            orderById.TotalAmount = order.TotalAmount;
            orderById.OrderType = order.OrderType;
            orderById.CreatedDate = order.CreatedDate;
            orderById.UpdatedDate = order.UpdatedDate;
            orderById.CreateBy = order.CreateBy;
            orderById.UpdateBy = order.UpdateBy;
            orderById.Status = order.Status;    
            orderById.CounterId = order.CounterId;

            context.Orders.Update(orderById);
            context.SaveChanges();
            return true;
        }

        public int TotalItem()
        {
            JewelryProductionContext context = new JewelryProductionContext();
            return context.Orders.Count();
        }

        public List<Order> SearchOrders(int page, int size, string? orderCode, DateTime? startDate, DateTime? endDate)
        {
            JewelryProductionContext context = new JewelryProductionContext();

            var query = context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(orderCode))
            {
                query = query.Where(o => o.Id.ToString() == orderCode);
            }

            if (startDate.HasValue)
            {
                query = query.Where(o => o.CreatedDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(o => o.CreatedDate <= endDate.Value);
            }

            return query.Skip((page - 1) * size)
                        .Take(size)
                        .ToList();
        }
    }
}
