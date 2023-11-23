using AspNETWebAPIDers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
