using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Orders_Managment_System.Dtos;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Orders_Managment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly JwtOptions _options;
        private readonly IUserRepositry _user;

        public UserController(IOptions<JwtOptions> options,IUserRepositry user)
        {
            _options = options.Value;
            _user = user;
        }
        [HttpPost]
        [Route("/createuser")]
        public async Task<ActionResult<User>> RegisterUser(UserDto userdto)
        {
            await _user.CreateUserAsync(userdto);
           
            return Ok();
        }




        [HttpPost]
        [Route("")]
        public  ActionResult<string> Authenticaton(UserDto user)
        {
            var userfound = _user.FindUserAsync(user);
            if(userfound != null) { 

                var tokenhandler = new JwtSecurityTokenHandler();
                var encodedsigningkey = Encoding.UTF8.GetBytes(_options.SigningKey);


                var tokendescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _options.Issuer,
                    Audience = _options.Audience,
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(encodedsigningkey)
                    , SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, user.Name),
                    new(ClaimTypes.Role, user.role)
                })
                };
                var secuirtytoken = tokenhandler.CreateToken(tokendescriptor);
                var accesstoken = tokenhandler.WriteToken(secuirtytoken);
                return Ok(accesstoken);
            }
            return NotFound();
            
        }
    }
}
