using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JewelryProduction.DAO
{
    public class StoneDAO
    {
        public StoneDAO() { }

        public List<Stone> GetStones(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Stones
                    .Where(s => s.Status == "ACTIVE")
                    .OrderByDescending(s => s.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        public List<Stone> GetStonesWithoutPaging()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Stones
                    .Where(s => s.Status == "ACTIVE")
                    .OrderByDescending(s => s.CreateDate)
                    .ToList();
            }
        }

        public Stone GetStoneById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Stones.FirstOrDefault(s => s.Id.Equals(id));
            }
        }

        public Stone Create(Stone stone)
        {
            using (var context = new JewelryProductionContext())
            {
                stone.Id = Guid.NewGuid();
                stone.Status = "ACTIVE";
                context.Stones.Add(stone);
                context.SaveChanges();
                return stone;
            }
        }

        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var stone = context.Stones.FirstOrDefault(s => s.Id.Equals(id));
                if (stone == null)
                {
                    return false;
                }

                stone.Status = stone.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.Stones.Update(stone);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid id, Stone updatedStone)
        {
            using (var context = new JewelryProductionContext())
            {
                var stone = context.Stones.FirstOrDefault(s => s.Id.Equals(id));
                if (stone == null)
                {
                    return false;
                }

                stone.StoneType = updatedStone.StoneType;
                stone.Name = updatedStone.Name;
                stone.Price = updatedStone.Price;
                stone.Status = updatedStone.Status;
                stone.CreateDate = updatedStone.CreateDate;
                stone.CreateBy = updatedStone.CreateBy;
                stone.UpdateDate = updatedStone.UpdateDate;
                stone.UpdateBy = updatedStone.UpdateBy;
                // Other properties...

                context.Stones.Update(stone);
                context.SaveChanges();
                return true;
            }
        }

        public int TotalItem()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Stones.Count();
            }
        }
    }
}
