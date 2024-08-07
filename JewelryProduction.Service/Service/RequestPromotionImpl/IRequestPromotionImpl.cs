﻿using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Response.RequestPromotion;

namespace JewelryProduction.Service.Service.RequestPromotionImpl
{
    public interface IRequestPromotionImpl
    {
        public List<GetRequestPromotionResponse> GetRequestPromotions();
        public GetRequestPromotionResponse? GetRequestPromotionById(Guid id);
        public GetRequestPromotionResponse? Create(RequestPromotion? request);
        public void ChangeStatus(Guid id, string status);
    }
}
