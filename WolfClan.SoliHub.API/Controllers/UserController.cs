using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoayaApp.API.Auth;
using WolfClan.SoliHub.API.Auth;

namespace WolfClan.SoliHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<User> userRpository;
        private IConfiguration _config;

        public UserController(IConfiguration config, IUserRepository<User> userRpository)
        {
            _config = config;

            this.userRpository = userRpository;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("/login")]

        public IActionResult Login([FromBody]LoginModel model
            )
        {
            IActionResult response = Unauthorized();
            var user = userRpository.FindWithEmail(model.Email);
            if (user != null)
            {
                string StringPassword = Encoding.UTF8.GetString(user.Password);
                if (StringPassword==model.Password)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                }
              
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/Register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            IActionResult response = Conflict();
            var user = userRpository.FindWithEmail(model.Email);

            if (user == null && model.Password == model.ConfirmPassword)
            {
                byte[] BytesPassword = Encoding.UTF8.GetBytes(model.Password);
                var newUser = new User {FirstName=model.FirstName,LastName=model.LastName,Email=model.Email,Password= BytesPassword };

                userRpository.Add(newUser);
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { model.Email , token = tokenString });
            }

            return response;
        }
        // GET: api/User
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/User
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
