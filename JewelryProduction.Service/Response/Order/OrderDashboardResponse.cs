using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Response.Order
{
    public class OrderDashboardResponse
    {
        public int NumberOfOrders {  get; set; }

        public decimal Sales {  get; set; }

        public int NumberOfProduct { get; set; }
    }
}
