using Microsoft.AspNetCore.Mvc;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Service;

namespace Shopping_Tutorial.Controllers
{
	[ApiController]
	[Route("api/feed-back")]
	public class FeedBackController :ControllerBase
	{
		private FeedBackService	feedBackService;

		public FeedBackController(FeedBackService feedBackService)
		{
			this.feedBackService = feedBackService;
		}


		[HttpPost("insert-feedback")]
		public async Task<IActionResult> FeedBack(FeedBackRequest feedBackRequest)
		{
			var FeedBack = await feedBackService.FeedBack(feedBackRequest);
			return Ok(FeedBack);
		}
		[HttpGet("get-all-feedback")]
		public async Task<ActionResult<IEnumerable<FeedBackModel>>> GetAllFeedBack()
		{
			var FeedBacks = await feedBackService.GetAllFeedBack();
			return Ok(FeedBacks);
		}
	}
}
