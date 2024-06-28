using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Response.Order
{
    public class Top5CustomerResponse
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int TotalOrder { get; set; }
    }
}
