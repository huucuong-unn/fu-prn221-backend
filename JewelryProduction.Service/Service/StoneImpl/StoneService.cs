using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Paginate;
using JewelryProduction.Repository.StoneRepository;
using JewelryProduction.Service.Converters;
using JewelryProduction.Service.Request.Stone;
using JewelryProduction.Service.Response.Stone;

namespace JewelryProduction.Service.Service.Stone
{
    public class StoneService : IStoneService
    {
        private readonly IStoneRepository stoneRepository;

        public StoneService()
        {
            if (stoneRepository == null)
            {
                stoneRepository = new StoneRepository();
            }
        }

        public GetStoneResponse Create(GetStoneRequest createStoneRequest)
        {
            BusinessObject.Models.Stone Stone = StoneConverter.toEntityForCreate(createStoneRequest);
            BusinessObject.Models.Stone newStone = stoneRepository.Create(Stone);
            return StoneConverter.toDto(newStone);
        }

        public bool ChangeStatus(Guid id)
        {
            return stoneRepository.ChangeStatus(id);
        }

        public GetStoneResponse GetById(Guid id)
        {
            BusinessObject.Models.Stone stone = stoneRepository.GetStoneById(id);
            return StoneConverter.toDto(stone);
        }

        public PagingModel<GetStoneResponse> GetAll(FilterModel filterModel)
        {
            PagingModel<GetStoneResponse> result = new PagingModel<GetStoneResponse>();
            result.Page = filterModel.PageIndex;
            List<BusinessObject.Models.Stone> stones = stoneRepository.GetStones(filterModel);
            List<GetStoneResponse> getStoneResponses = stones.Select(stone =>
            {
                return StoneConverter.toDto(stone);
            }).ToList();

            result.ListResult = getStoneResponses;
            result.TotalPages = ((int)Math.Ceiling((double)(TotalStone()) / filterModel.PageSize));
            result.Size = filterModel.PageSize;
            return result;
        }

        public int TotalStone()
        {
            return stoneRepository.TotalStone();
        }

        public bool Update(Guid id, GetStoneRequest updateStoneRequest)
        {
            BusinessObject.Models.Stone stone = StoneConverter.toEntityForUpdate(updateStoneRequest);
            return stoneRepository.Update(id, stone);
        }
    }
}
