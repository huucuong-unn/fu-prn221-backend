using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.UserRepository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly OrderItemDAO orderitemDAO;

        public OrderItemRepository() {
        if (orderitemDAO == null)
            {
                orderitemDAO = new OrderItemDAO();
            }
        }

        public OrderItem Create(OrderItem orderitem)
        {
            return orderitemDAO.Create(orderitem);
        }

        public bool ChangeStatus(Guid id)
        {
            return orderitemDAO.ChangeStatus(id);
        }

        public OrderItem GetOrderItemById(Guid id)
        {
            return orderitemDAO.GetOrderItemById(id);
        }

        public List<OrderItem> GetOrderItems(FilterModel filterModel)
        {
            return orderitemDAO.GetOrderItems(filterModel);
        }

        public bool Update(Guid id, OrderItem orderitem)
        {
            return orderitemDAO.Update(id, orderitem);
        }

        public int TotalItem()
        {
            return orderitemDAO.TotalItem();
        }
    }
}
