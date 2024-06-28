using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Response.ProductType
{
    public class GetProductTypeWithTotalOrder
    {
        public string ProductTypeName {  get; set; }

        public int TotalOrder {  get; set; }
    }
}
