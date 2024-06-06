using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.BusinessObject.Filter
{
    public class FilterModel
    {
        public FilterModel() {
            PageIndex = 1;
            PageSize = 10;
            Status = "ACTIVE";
            OrderBy = "Vinh";
        }

        public int PageSize {  get; set; }
        public int PageIndex { get; set; }
        public string Status { get; set; }
        public string OrderBy {  get; set; }
    }
}
