using AspNETWebAPIDers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNETWebAPIDers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ResponseModel _responseModel;

        public AuthController(ResponseModel responseModel)
        {
            _responseModel = responseModel;
        }

        [HttpPost()]
        public ResponseModel Login(LoginModel loginModel)
        {
            if (loginModel.UserName == "sinan" && loginModel.Password == "123")
            {
                _responseModel.Message = "Login işlemi başarılı";
                _responseModel.Code = "200";
                _responseModel.Data = null;
                return _responseModel;
            }

            _responseModel.Message = "Login işlemi başarısız";
            _responseModel.Code = "401";
            _responseModel.Data = null;
            return _responseModel;
        }


    }
}
