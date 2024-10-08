﻿using ChatAppApi.AppSetting;
using ChatAppApi.Model;
using ChatAppApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatAppApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private readonly ApplicationSettings appSettings;

        const string password = "default123@^";

        public AccountController(UserManager<ApplicationUser> userManager, IOptions<ApplicationSettings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this.userManager.Users.ToList();
            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/account/Register
        public async Task<Object> Register([FromBody]RegisterRequest model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };


            try
            {
                var result = await this.userManager.CreateAsync(applicationUser, password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/account/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                try
                {

                    IdentityOptions _options = new IdentityOptions();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {

                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim("UserID",user.Id.ToString()),
                        new Claim("UserName",user.UserName),
                        new Claim("FullName",user.FirstName+" "+user.LastName),

                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    
                    return Ok(new { token, user });
                }
                catch (Exception exp)
                {
                    throw;
                }
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}
