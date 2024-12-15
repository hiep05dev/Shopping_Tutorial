using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.DTO.Request
{
	public class CartRequest
	{	
		public int ProductId { get; set; }
		public int  UserId { get; set; }

		public int Quantity { get; set; }

	
	}
}
