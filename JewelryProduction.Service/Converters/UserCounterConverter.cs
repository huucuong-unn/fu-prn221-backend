using JewelryProduction.BusinessObject.Models;
using JewelryProduction.Service.Request.UserCounter;
using JewelryProduction.Service.Response.UserCounter;
using System;

namespace JewelryProduction.Service.Converters
{
    public class UserCounterConverter
    {
        public static GetUserCounterResponse ToDto(UserCounter userCounter)
        {
            GetUserCounterResponse getUserCounterResponse = new GetUserCounterResponse();
            getUserCounterResponse.StaffId = userCounter.StaffId;
            getUserCounterResponse.CounterId = userCounter.CounterId;
            getUserCounterResponse.Status = userCounter.Status;
            return getUserCounterResponse;
        }

        public static UserCounter ToEntity(GetUserCounterRequest request)
        {
            UserCounter userCounter = new UserCounter();
            userCounter.StaffId = request.StaffId;
            userCounter.CounterId = request.CounterId;
            userCounter.Status = request.Status; 
            return userCounter;
        }

        public static void UpdateEntity(GetUserCounterRequest request, UserCounter userCounter)
        {
            userCounter.StaffId = request.StaffId; 
            userCounter.CounterId = request.CounterId; 
            userCounter.Status = request.Status;
        }
    }
}
