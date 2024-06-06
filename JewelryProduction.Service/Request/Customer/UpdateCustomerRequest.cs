using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.Customer
{
    public class UpdateCustomerRequest : BaseCustomerRequest
    {
        public string Status { get; set; }
    }
}
