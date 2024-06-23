using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.Material
{
    public class BaseMaterialRequest
    {
        public string name {  get; set; }

        public decimal buyingPrice { get; set; }

        public decimal salePrice { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
