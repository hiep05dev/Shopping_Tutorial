using Microsoft.AspNetCore.Mvc;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Service;
using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.Controllers
{
	[ApiController]
	[Route("api/user")] 
	public class UserController : ControllerBase  
	{
		private readonly UserService _userService;
		public UserController(UserService userService)
		{
			_userService = userService;
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login(UserRequest userRequest)
		{
			var user = await _userService.Login(userRequest);
			if (user == null)
			{		
				return Unauthorized(new { message = "Thông tin đăng nhập không hợp lệ" });
			}		
			return Ok(user);  
		}
	}
}
