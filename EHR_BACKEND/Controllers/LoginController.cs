using EasyHouseRent;
using EasyHouseRent.Model;
using EHR_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHR_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        BaseData _db = new BaseData();
        private readonly IConfiguration _configuration;
        public object AdapterTable { get; private set; }

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // POST api/<LoginController>
        [HttpPost]
        public ActionResult Post([FromQuery] LoginData loginData)
        {
            string sql = $"SELECT nombre, apellidos, edad, email,telefono FROM usuarios where email = '{loginData.email}' and contraseña = '{Encrypt.GetSHA256(loginData.password)}'";
            string result = _db.ConvertDataTabletoString(sql);
            if (result == "[]")
            {

                return BadRequest(new { isAuth = false });
            }
            else
            {

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(createdToken);

                return Ok(new { isAuth = true, data = result, token = token });

            }

        }
    }
}
