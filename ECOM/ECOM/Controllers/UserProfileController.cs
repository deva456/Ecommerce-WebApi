using ECOM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<UserProfile> _userManager;
        private SignInManager<UserProfile> _signinManager;
        private readonly ApplicationSettings _appSettings;
        public UserProfileController(UserManager<UserProfile> userManager, SignInManager<UserProfile> signinManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _appSettings = appSettings.Value;
        }

        
        //Post Method for registration form 
        [HttpPost]
        [Route("Register")]
        //Post:/api/UserProfile/Register
        public async Task<Object> PostUserProfile(Register model)
        {
            

           model.role = "Customer";
            

            var UserProfile = new UserProfile()
            {
            
                firstName = model.firstName,
                lastName = model.lastName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                dob = model.dob,
                Address=model.Address
            };
            try
            {

                var result = await _userManager.CreateAsync(UserProfile, model.Password);
                await _userManager.AddToRoleAsync(UserProfile, model.role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        //Post Method for registration form 
        [HttpPost]
        [Route("Login")]
        //Post:/api/UserProfile/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or Password is incorrect." });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web method for Admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetCustomer()
        {
            return "Web method for Customer";
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        [Route("ForAdminOrCustomer")]
        public string GetForAdminOrCustomer()
        {
            return "Web method for Admin or Customer";
        }

    }
}
