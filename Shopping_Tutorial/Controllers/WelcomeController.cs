using Microsoft.AspNetCore.Mvc;

namespace Shopping_Tutorial.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WelcomeController : ControllerBase
	{
		// GET: api/Welcome
		[HttpGet]
		public IActionResult GetWelcomeMessage()
		{
			return Ok("Welcome");
		}
	}
}
