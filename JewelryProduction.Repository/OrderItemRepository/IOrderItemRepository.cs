using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.UserRepository
{
    public interface IOrderItemRepository
    {
        public List<OrderItem> GetOrderItems(FilterModel filterModel);

        public OrderItem GetOrderItemById(Guid id);

        public OrderItem Create(OrderItem orderitem);

        public bool Update(Guid id, OrderItem orderitem);

        public bool ChangeStatus(Guid id);

        public int TotalItem();

        public List<OrderItem> GetOrderItemsByOrderId(Guid orderId);
    }
}
