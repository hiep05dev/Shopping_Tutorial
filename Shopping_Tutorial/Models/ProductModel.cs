using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.Models
{
    public class ProductModel
    {
		[Key]
        public int id {  get; set; }
		[Required, MinLength(4, ErrorMessage = "nhập tên sản phẩm")]
		public string name { get; set; }
		[Required, MinLength(4, ErrorMessage = "nhập mô tả  sản phẩm")]
		public string description { get; set; }
		[Required, MinLength(4, ErrorMessage = "nhập giá  sản phẩm")]
		public int price { get; set; }
		public string size { get; set; }
		public string color  { get; set; }
		public int stock { get; set; }
		public byte [] imgae { get; set; }

	    public int CategoryId { get; set; }
		public CategoryModel Category { get; set; }
		

		
	}
}
