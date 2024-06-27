using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO orderDAO;

        public OrderRepository()
        {
            if (orderDAO == null)
            {
                orderDAO = new OrderDAO();
            }
        }
        public Order Create(Order order)
        {
            return orderDAO.Create(order);
        }

        public bool Delete(Guid id)
        {
            return orderDAO.Delete(id);
        }

        public Order GetById(Guid id)
        {
            return orderDAO.GetById(id);
        }

        public List<Order> GetOrders(FilterModel filterModel)
        {
            return orderDAO.GetOrders(filterModel);
        }

        public int TotalItem()
        {
            return orderDAO.TotalItem();
        }

        public bool Update(Guid id, Order order)
        {
            return orderDAO.Update(id, order);
        }

        public List<Order> SearchOrders(int page, int size, string orderCode, DateTime? startDate, DateTime? endDate)
        {
            return orderDAO.SearchOrders(page, size, orderCode, startDate, endDate);
        }
    }
}
