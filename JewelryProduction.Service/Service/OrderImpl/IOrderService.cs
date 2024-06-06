using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Service.Request.Customer;
using JewelryProduction.Service.Request.User;
using JewelryProduction.Service.Response.Customer;
using JewelryProduction.Service.Response.Order;
using JewelryProduction.Service.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.CustomerImpl
{
    public interface IOrderService
    {
        public PagingModel<GetOrderReponse> GetAll(FilterModel filterModel);

        public GetOrderReponse GetById(Guid id);

        public GetOrderReponse Create(CreateOrderRequest createOrderRequest);

        public bool Update(Guid id, UpdateOrderRequest updateOrderRequest);

        public bool Delete(Guid id);

        public int TotalItem();
    }
}
