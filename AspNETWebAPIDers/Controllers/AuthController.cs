using AspNETWebAPIDers.Models;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNETWebAPIDers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        [HttpPost()]
        public ResponseModel Login(LoginModel loginModel)
        {
            var response = new ResponseModel();

            var signinKey = "BuBenimSigninKeyim12456789BuBenimSigninKeyim12456789BuBenimSigninKeyim12456789BuBenimSigninKeyim12456789";
            var credential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey)), SecurityAlgorithms.HmacSha512);
            var encoded = JWT.Encode(loginModel.UserName, Encoding.UTF8.GetBytes(signinKey),JwsAlgorithm.HS512);
            var decoded = JWT.Decode(encoded, Encoding.UTF8.GetBytes(signinKey), JwsAlgorithm.HS512);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, encoded)
            };

            var securityToken = new JwtSecurityToken(
                issuer: "https://www.sinancan.com",
                audience: "Butokenbizizleyicileriçin",
                expires: DateTime.Now.AddDays(2),
                notBefore: DateTime.Now,
                claims:claims,
                signingCredentials: credential
                );
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            if (loginModel.UserName == "sinan" && loginModel.Password == "123")
            {
                response.Message = "Login işlemi başarılı";
                response.Code = "200";
                response.Data = null;
                return response;
            }

            response.Message = "Login işlemi başarısız";
            response.Code = "401";
            response.Data = null;
            return response;
        }


    }
}
