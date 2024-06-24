using JewelryProduction.Service.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.Customer
{
    public class CreateOrderRequest : BaseOrderRequest
    {
        public string? CustomerName { get; set; }

        public string? CustomerPhone { get; set;}

        public List<string>? ListProductCode { get; set; }

    }
}
