using Microsoft.AspNetCore.Mvc;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Service;

namespace Shopping_Tutorial.Controllers
{
	[ApiController]
	[Route("api/cart")]
	public class CartController:ControllerBase
	{
		private CartService cartService;

		public CartController(CartService cartService)
		{
			this.cartService = cartService;
		}

		[HttpPost("insert-cart")]
		public async Task<ActionResult> InserCart ([FromBody] CartRequest cartRequest)
		{
			var cart = await cartService.InsertCart (cartRequest);
			return Ok(cart);
		}
		[HttpGet("get-all-cart-by-user")]
		public async Task<ActionResult>GetAllCartByUser ([FromQuery]int userId)
		{
			var cart = await cartService.GetAllCartByUserId (userId);
			return Ok(cart);
		}

		[HttpDelete("delete-cart-by-id")]
		public async Task<ActionResult> DeleteCartById([FromQuery]int id)
		{
			var cart = await cartService.DeleteCartById (id);	
			return Ok(cart);
		}
	}
}
