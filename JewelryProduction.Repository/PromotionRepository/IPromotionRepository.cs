using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.PromotionRepository
{
    public interface  IPromotionRepository
    {
        public List<Promotion> GetPromotions(FilterModel filterModel);


        public Promotion GetPromotionById(Guid id);


        public Promotion Create(Promotion promotion);


        public bool ChangeStatus(Guid id);


        public bool Update(Guid id, Promotion promotion);


        public int TotalCounter();
    }
}
