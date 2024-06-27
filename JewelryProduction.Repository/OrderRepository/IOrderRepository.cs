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
    public interface IOrderRepository
    {
        public List<Order> GetOrders(FilterModel filterModel);

        public Order GetById(Guid id);

        public Order Create(Order order);

        public bool Delete(Guid id);

        public bool Update(Guid id, Order order);

        public int TotalItem();

        public List<Order> SearchOrders(int page, int size, string? orderCode, DateTime? startDate, DateTime? endDate);

    }
}
