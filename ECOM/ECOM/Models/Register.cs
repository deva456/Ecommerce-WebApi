using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Models
{
    public class Register
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        
        public DateTime dob { get; set; }

        public string Address { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
        public string PhoneNumber { get; set; }
        public string role { get; set; }


    }
}
