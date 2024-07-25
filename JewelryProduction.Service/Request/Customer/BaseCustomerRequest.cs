﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.Customer
{
    public class BaseCustomerRequest
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public string Status { get; set; }

    }
}
