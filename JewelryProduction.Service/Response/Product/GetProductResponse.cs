﻿using System;

namespace JewelryProduction.Service.Response.Product
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}