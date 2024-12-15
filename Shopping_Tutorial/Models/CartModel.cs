using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.Models
{
	public class CartModel
	{
	[Key]
	public 	int Id { get; set; }
		public int ProductId { get; set; }
		public int  UserId { get; set; }

		public int Quantity { get; set; }

		public ProductModel Product { get; set; } 
	    public UserModel User  { get; set; }
	}
}
