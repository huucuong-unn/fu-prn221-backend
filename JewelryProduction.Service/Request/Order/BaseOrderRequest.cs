using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.Order
{
    public class BaseOrderRequest
    {
        

        public Guid CustomerId { get; set; }

        public Guid PromotionId { get; set; }

        public decimal TotalAmount { get; set; }

        public string OrderType { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreateBy { get; set; }

        public string UpdateBy { get; set; }

        
    }
}
