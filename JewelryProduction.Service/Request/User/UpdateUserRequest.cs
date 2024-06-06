using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Request.User
{
    public class UpdateUserRequest : BaseUserRequest
    {
        public string Status { get; set; }
    }
}
