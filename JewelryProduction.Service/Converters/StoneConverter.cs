using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.Stone;
using JewelryProduction.Service.Response.Stone;
using System;

namespace JewelryProduction.Service.Converters
{
    public class StoneConverter
    {
        public static GetStoneResponse toDto(Stone Stone)
        {
            GetStoneResponse getStoneResponse = new GetStoneResponse();
            getStoneResponse.Id = Stone.Id;
            getStoneResponse.Name = Stone.Name;
            getStoneResponse.StoneType = Stone.StoneType;
            getStoneResponse.Price = Stone.Price;
            getStoneResponse.Status = Stone.Status;
            getStoneResponse.CreateDate = (DateTime)Stone.CreateDate;
            getStoneResponse.CreateBy = Stone.CreateBy;
            getStoneResponse.UpdateDate = (DateTime)Stone.UpdateDate;
            getStoneResponse.UpdateBy = Stone.UpdateBy;
            return getStoneResponse;
        }

        public static Stone toEntityForCreate(GetStoneRequest createStoneRequest)
        {
            Stone Stone = new Stone();
            Stone.Name = createStoneRequest.Name;
            Stone.StoneType = createStoneRequest.StoneType;
            Stone.Price = createStoneRequest.Price;
            Stone.Status = "ACTIVE";
            Stone.CreateDate = DateTime.Now;
            Stone.CreateBy = createStoneRequest.CreateBy;
            Stone.UpdateDate = DateTime.Now;
            Stone.UpdateBy = createStoneRequest.UpdateBy;
            return Stone;
        }

        public static Stone toEntityForUpdate(GetStoneRequest updateStoneRequest)
        {
            Stone Stone = new Stone();
            Stone.Name = updateStoneRequest.Name;
            Stone.StoneType = updateStoneRequest.StoneType;
            Stone.Price = updateStoneRequest.Price;
            Stone.Status = updateStoneRequest.Status;
            Stone.CreateDate = updateStoneRequest.CreateDate;
            Stone.CreateBy = updateStoneRequest.CreateBy;
            Stone.UpdateDate = DateTime.Now;
            Stone.UpdateBy = updateStoneRequest.UpdateBy;
            return Stone;
        }
    }
}
