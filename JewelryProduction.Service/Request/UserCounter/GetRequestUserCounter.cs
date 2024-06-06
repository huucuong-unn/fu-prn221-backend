using System;

namespace JewelryProduction.Service.Request.UserCounter
{
    public class GetUserCounterRequest
    {
        public Guid StaffId { get; set; }
        public Guid CounterId { get; set; }
        
        public string Status { get; set; }
    }
}