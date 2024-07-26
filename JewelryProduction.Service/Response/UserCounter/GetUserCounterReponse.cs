using System;

namespace JewelryProduction.Service.Response.UserCounter
{
    public class GetUserCounterResponse
    {
        public Guid StaffId { get; set; }
        public Guid CounterId { get; set; }
        public string Status { get; set; }
        
        public decimal? Income { get; set; }
    }
}