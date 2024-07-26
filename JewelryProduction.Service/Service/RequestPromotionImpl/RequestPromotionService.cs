using JewelryProduction.Repository.RequestPromotionRepository;
using JewelryProduction.Repository.RequestRepository;
using JewelryProduction.Service.Response.RequestPromotion;

namespace JewelryProduction.Service.Service.RequestPromotionImpl
{
    public class RequestPromotionService : IRequestPromotionService
    {
        private readonly IRequestPromotionRepository requestPromotionRepository;

        public RequestPromotionService()
        {
            if (requestPromotionRepository == null)
            {
                requestPromotionRepository = new RequestPromotionRepository();
            }
        }
        public void ChangeStatus(Guid id, string status)
        {
            requestPromotionRepository.ChangeStatus(id, status);
        }

        public GetRequestPromotionResponse? Create(BusinessObject.Models.RequestPromotion? request)
        {
            BusinessObject.Models.RequestPromotion requestPromotion = requestPromotionRepository?.Create(request);
            GetRequestPromotionResponse getRequestPromotionResponse = new GetRequestPromotionResponse();
            getRequestPromotionResponse.Id = requestPromotion.Id;
            getRequestPromotionResponse.CounterName = requestPromotion.Counter.Name;
            getRequestPromotionResponse.StaffName = requestPromotion.Staff.Name;
            return getRequestPromotionResponse;
        }

        public GetRequestPromotionResponse? GetRequestPromotionById(Guid id)
        {
            BusinessObject.Models.RequestPromotion requestPromotion = requestPromotionRepository.GetRequestPromotionById(id);
            GetRequestPromotionResponse getRequestPromotionResponse = new GetRequestPromotionResponse();
            if (requestPromotion != null)
            {
                getRequestPromotionResponse.Id = requestPromotion.Id;
                getRequestPromotionResponse.CounterName = requestPromotion.Counter.Name;
                getRequestPromotionResponse.StaffName = requestPromotion.Staff.Name;
                getRequestPromotionResponse.CustomerName = requestPromotion.Customer.Name;
                getRequestPromotionResponse.UpdateBy = requestPromotion.UpdateBy;
                getRequestPromotionResponse.CreateBy = requestPromotion.CreateBy;
                getRequestPromotionResponse.Status = requestPromotion.Status;
                getRequestPromotionResponse.CreatedDate = requestPromotion.CreatedDate;
                getRequestPromotionResponse.UpdatedDate = requestPromotion.UpdatedDate;
            }
            else
            {
                return null;
            }

            return getRequestPromotionResponse;
        }

        public List<GetRequestPromotionResponse> GetRequestPromotions()
        {
            List<BusinessObject.Models.RequestPromotion> requestPromotions = requestPromotionRepository.GetRequestPromotions();
            List<GetRequestPromotionResponse> getRequests = new List<GetRequestPromotionResponse>();
            foreach (BusinessObject.Models.RequestPromotion item in requestPromotions)
            {
                GetRequestPromotionResponse getRequestPromotionResponse = new GetRequestPromotionResponse();

                getRequestPromotionResponse.Id = item.Id;
                getRequestPromotionResponse.CounterName = item.Counter.Name;
                getRequestPromotionResponse.CustomerName = item.Customer.Name;
                getRequestPromotionResponse.StaffName = item.Staff.Name;
                getRequestPromotionResponse.UpdateBy = item.UpdateBy;
                getRequestPromotionResponse.CreateBy = item.CreateBy;
                getRequestPromotionResponse.Status = item.Status;
                getRequestPromotionResponse.CreatedDate = item.CreatedDate;
                getRequestPromotionResponse.UpdatedDate = item.UpdatedDate;

                getRequests.Add(getRequestPromotionResponse);
            }


            return getRequests;
        }
    }
}
