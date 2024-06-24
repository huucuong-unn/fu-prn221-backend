using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Response.Material
{
    public class GetMaterialResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal BuyingPrice { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public decimal SalePrice { get; set; }
    }
}
