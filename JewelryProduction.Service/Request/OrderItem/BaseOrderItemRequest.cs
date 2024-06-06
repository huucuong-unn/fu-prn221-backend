using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.User
{
    public class BaseOrderItemRequest
    {


        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid WarrantyId { get; set; }

        public decimal TotalAmount { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }       

        public string CreateBy { get; set; }

        public string UpdateBy { get; set; }
       

    }
}
