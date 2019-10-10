using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Configuration;

namespace XCart.ViewModel
{
    public class LoginSuccess 
    {

        IConfiguration _config;

       

        public LoginSuccess(IConfiguration config)
        {
            _config = config;
           
        }

        public int id { get; set; }
        public string Role { get; set; }
        public string token { get; set; }
        public int response { get; set; }
        public string firstName { get; set; }

        public string que { get; set; }
        public string ans { get; set; }


        public string GenerateJSONWebToken(string user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user)
            };



            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }



    
}
