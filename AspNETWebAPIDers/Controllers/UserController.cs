using AutoMapper;
using LMS.Data.Entities;
using LMSServices.Models;
using LMSServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNETWebAPIDers.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{

		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UserController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<UserResponseModel>> GetAll()
		{
			var users = await _userService.GetAllAsync();
			return _mapper.Map<IEnumerable<UserResponseModel>>(users);
		}
		[HttpGet("{id}")]
		public async Task<UserResponseModel> Get(int id)
		{
			var user = _userService.GetByIdAsync(id);
			return _mapper.Map<UserResponseModel>(user);
		}

		[HttpPost]
		public async Task<UserResponseModel> Post([FromBody] UserRequestModel userRequestModel)
		{
			var userMap = _mapper.Map<User>(userRequestModel);
			var createdUser = await _userService.InsertAsnyc(userMap);
			return _mapper.Map<UserResponseModel>(createdUser);
		}

		[HttpPut]
		public async Task<UserResponseModel> Put([FromBody] UserRequestModel userRequestModel)
		{
			var user = _mapper.Map<User>(userRequestModel);

			var updatedUser = await _userService.UpdateAsnyc(user);
			return _mapper.Map<UserResponseModel>(updatedUser);
		}

		[HttpDelete("{id}")]
		public async Task<UserResponseModel> Delete(int id)
		{
			var deletedUser = await _userService.DeleteAsync(id);
			return _mapper.Map<UserResponseModel>(deletedUser);
		}
	}
}
