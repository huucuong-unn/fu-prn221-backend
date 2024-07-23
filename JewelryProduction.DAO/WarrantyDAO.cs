using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.DAO
{
    public class WarrantyDAO
    {
        public WarrantyDAO() { }

        //Get warranties list
        public List<Warranty> GetWarranties(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Warranties
                    .Where(c => c.Status == "ACTIVE")
                    .OrderByDescending(c => c.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        //Get warranty by id
        public Warranty? GetWarrantyById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Warranties.FirstOrDefault(c => c.WarrantyProductId == id);
            }
        }

        // create warranty
        public Warranty? Create(Warranty? warranty)
        {
            using (var context = new JewelryProductionContext())
            {
                warranty.WarrantyProductId = warranty.WarrantyProductId;
                warranty.Status = "ACTIVE";
                context.Warranties.Add(warranty);
                context.SaveChanges();
                return warranty;
            }
        }

        //change status warranty
        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var warranty = context.Warranties.FirstOrDefault(c => c.WarrantyProductId == id);
                if (warranty == null)
                {
                    return false;
                }

                warranty.Status = warranty.Status == "ACTIVE" ? "INACTIVE" : "ACTIVE";
                context.Warranties.Update(warranty);
                context.SaveChanges();
                return true;
            }
        }

        // update warranty
        public bool Update(Guid id, Warranty warranty)
        {
            using (var context = new JewelryProductionContext())
            {
                var existingWarranty = context.Warranties.FirstOrDefault(c => c.WarrantyProductId == id);
                if (existingWarranty == null)
                {
                    return false;
                }

                existingWarranty.StartDate = warranty.StartDate;
                existingWarranty.EndDate = warranty.EndDate;
                existingWarranty.Description = warranty.Description;
                existingWarranty.UpdateDate = warranty.UpdateDate;
                existingWarranty.UpdateBy = warranty.UpdateBy;

                context.Warranties.Update(existingWarranty);
                context.SaveChanges();
                return true;
            }
        }

        //count total counter
        public int TotalCounter()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Warranties.Count();
            }
        }

        //Delete warranty
        public bool Delete(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                bool result = context.Warranties.Remove(GetWarrantyById(id)) != null;
                context.SaveChanges();
                return result;
            }
        }
    }

}
