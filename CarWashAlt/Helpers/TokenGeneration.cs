using CarWashAlt.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarWashAlt.Helpers
{
    public class TokenGeneration
    {


        public string CreateJwt(UserDetails user)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("This Will Be Used To Generate Tokens For The Project");

                //creating payload
                var identity = new ClaimsIdentity(new Claim[]
                    {
                    new Claim( ClaimTypes.Role,user.Role),
                    new Claim ( ClaimTypes.Name,$"{ user.FirstName} { user.LastName}"),
                    new Claim( ClaimTypes.PrimarySid,user.UserId.ToString())
                    });
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                return jwtTokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
