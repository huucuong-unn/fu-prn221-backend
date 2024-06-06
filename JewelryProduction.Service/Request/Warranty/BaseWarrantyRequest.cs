using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.Warranty
{
    public class BaseWarrantyRequest
    {
        public Guid Id { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdateBy { get; set; }
    }
}
