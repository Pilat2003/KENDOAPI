using Kendo.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace Kendo.Data
{
    public class JwtAuthenricationManager : IJwtAuthenticationManager
    {
        private SecurityTokenDescriptor tokenDescriptor;
        private static JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        private IcommanderRepo _repo;
        private readonly string _key = "Some random key1233456789";

        private bool _ini = false;
        public void init()
        {
          
        }

        public string GetIDFromToken(string token)
        {
            try
            {
                if (tokenHandler.CanReadToken(token))
                {
                    return tokenHandler.ReadJwtToken(token).
                        Claims.First(r => r.Type == "Id").
                        Value;
                }
                else
                    System.Diagnostics.Debug.WriteLine("Cannot Read token");
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string MakeNewToken(string username, string id)
        {

     
            tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("Id", id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            


            return tokenHandler.WriteToken(token);
        }
    }
}
