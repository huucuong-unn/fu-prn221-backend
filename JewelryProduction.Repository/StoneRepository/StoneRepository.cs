using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using JewelryProduction.DAO;
using System;
using System.Collections.Generic;

namespace JewelryProduction.Repository.StoneRepository
{
    public class StoneRepository : IStoneRepository
    {
        private readonly StoneDAO stoneDAO;

        public StoneRepository()
        {
            if (stoneDAO == null)
            {
                stoneDAO = new StoneDAO();
            }
        }

        public Stone Create(Stone stone)
        {
            return stoneDAO.Create(stone);
        }

        public bool ChangeStatus(Guid id)
        {
            return stoneDAO.ChangeStatus(id);
        }
        

        public Stone GetStoneById(Guid id)
        {
            return stoneDAO.GetStoneById(id);
        }

        public List<Stone> GetStones(FilterModel filterModel)
        {
            return stoneDAO.GetStones(filterModel);
        }

        public bool Update(Guid id, Stone stone)
        {
            return stoneDAO.Update(id, stone);
        }

        public int TotalStone()
        {
            return stoneDAO.TotalItem();
        }

        public List<Stone> GetStonesWithoutPaging()
        {
            return stoneDAO.GetStonesWithoutPaging();
        }
    }
}