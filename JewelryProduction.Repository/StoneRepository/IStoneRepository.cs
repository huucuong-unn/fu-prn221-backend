using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;

namespace JewelryProduction.Repository.StoneRepository
{
    public interface IStoneRepository
    {
        List<Stone> GetStones(FilterModel filterModel);

        Stone GetStoneById(Guid id);

        Stone Create(Stone stone);

        bool Update(Guid id, Stone stone);

        bool ChangeStatus(Guid id);

        int TotalStone();
    }
}