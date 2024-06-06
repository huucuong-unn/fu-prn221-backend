using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.BusinessObject.Paginate
{
    public class PagingModel<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
        public List<T> ListResult { get; set; }
    }
}
