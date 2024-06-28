using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
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

        public decimal GetTotalRevenue()
        {
            using (var context = new JewelryProductionContext())
            {
                return (decimal)context.Orders
                    .Where(o => o.Status == "ACTIVE")
                    .Sum(o => o.TotalAmount);
            }
        }

        public Dictionary<string, decimal> GetMonthlyRevenue()
        {
            using (var context = new JewelryProductionContext())
            {
                var currentYear = DateTime.Now.Year;
                var monthlyRevenue = context.Orders
                    .Where(o => o.Status == "ACTIVE" && o.CreatedDate.Value.Year == currentYear)
                    .GroupBy(o => new { o.CreatedDate.Value.Month })
                    .Select(g => new
                    {
                        Month = g.Key.Month,
                        TotalAmount = g.Sum(o => o.TotalAmount)
                    })
                    .ToDictionary(x => x.Month, x => x.TotalAmount ?? 0);

                // Tạo danh sách đầy đủ 12 tháng 
                var allMonths = Enumerable.Range(1, 12).Select(month => new
                {
                    Month = month,
                    TotalAmount = monthlyRevenue.ContainsKey(month) ? monthlyRevenue[month] : 0m
                }).ToDictionary(x => $"{x.Month}/{currentYear}", x => x.TotalAmount);

                return allMonths;
            }
        }

        public Dictionary<string, int> GetMonthlyOrderCount()
        {
            using (var context = new JewelryProductionContext())
            {
                var currentYear = DateTime.Now.Year;

                var monthlyOrderCount = context.Orders
                    .Where(o => o.Status == "ACTIVE" && o.CreatedDate.Value.Year == currentYear)
                    .GroupBy(o => o.CreatedDate.Value.Month)
                    .Select(g => new
                    {
                        Month = g.Key,
                        OrderCount = g.Count()
                    })
                    .ToDictionary(x => $"{x.Month}", x => x.OrderCount);

                return monthlyOrderCount;
            }
        }

    }
}
