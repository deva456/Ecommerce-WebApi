using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECOM.DbContext;
using ECOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private UserManager<UserProfile> _userManager;
        private EcomdbContext _context;
        public UserDetailsController(UserManager<UserProfile> userManager, EcomdbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]

        //Get:/api/UserDetails
        public async Task<Object> GetUserDetails()
        {
           string UserId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(UserId);
            return new
            {
                user.Id,
                user.dob,
                user.Email,
                user.UserName,
                user.PhoneNumber,
                user.firstName,
                user.lastName,
                user.Address
               


            };
        }


    }
}
