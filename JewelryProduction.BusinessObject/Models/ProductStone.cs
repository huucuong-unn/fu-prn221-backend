using System;

namespace JewelryProduction.BusinessObject.Models
{
    public class ProductStone
    {
        public Guid ProductId { get; set; }
        public Guid StoneId { get; set; }

        public virtual Product Product { get; set; } 
        public virtual Stone Stone { get; set; } 
    }
}