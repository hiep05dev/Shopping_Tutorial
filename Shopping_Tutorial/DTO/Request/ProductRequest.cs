using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.DTO.Request
{
	public class ProductRequest
	{
		
	
		public string Name { get; set; }
		
		public string Description { get; set; }
		
		public int Price { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int Stock { get; set; }
	
		public IFormFile Image { get; set; }
		public int CategoryId { get; set; }

		
	}
}
