using AspNETWebAPIDers.Models.User;
using LMS.Data.Entities;
using LMS.Data.Repositories.UserRepository;
using LMSServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AspNETWebAPIDers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.GetByIdAsync(id);
        }
        [HttpPost]
        public async Task<User> Post([FromBody] UserRequestModel userRequestModel)
        {
            var user = new User
            {
                FirsName = userRequestModel.FirsName,
                LastName = userRequestModel.LastName,
                Email = userRequestModel.Email,
                Password = userRequestModel.Password,
                RoleId = userRequestModel.RoleId,
            };
            return await _userService.InsertAsnyc(user);
        }
        [HttpPut]
        public async Task<User> Put([FromBody] User user)
        {
            return await _userService.UpdateAsnyc(user);
        }
        [HttpDelete("{id}")]
        public async Task<User> Delete(int id)
        {
            return await _userService.DeleteAsync(id);
        }
    }
}
