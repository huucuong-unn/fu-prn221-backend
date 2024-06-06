using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryProduction.Service.Response.User
{
    public class GetUsersReponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public decimal Income { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreateBy { get; set; }

        public string UpdateBy { get; set; }

        public string Status { get; set; }
    }
}
