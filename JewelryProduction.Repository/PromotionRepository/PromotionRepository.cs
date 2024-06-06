using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Repository.PromotionRepository
{
    public class PromotionRepository:IPromotionRepository
    {
        private readonly PromotionDAO promotionDAO;

        public PromotionRepository()
        {
            if (promotionDAO == null)
            {
                promotionDAO = new PromotionDAO();
            }
        }

        public Promotion Create(Promotion promotion)
        {
            return promotionDAO.Create(promotion);
        }

        public bool ChangeStatus(Guid id)
        {
            return promotionDAO.ChangeStatus(id);
        }


        public Promotion GetPromotionById(Guid id)
        {
            return promotionDAO.GetPromotionById(id);
        }

        public List<Promotion> GetPromotions(FilterModel filterModel)
        {
            return promotionDAO.GetPromotions(filterModel);
        }

        public bool Update(Guid id, Promotion promotion)
        {
            return promotionDAO.Update(id, promotion);
        }

        public int TotalCounter()
        {
            return promotionDAO.TotalCounter();
        }
    }
}

