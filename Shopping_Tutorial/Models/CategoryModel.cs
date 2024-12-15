using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.Models
{
	public class CategoryModel
	{
		[Key]
		public int id { get; set; }
		[Required, MinLength(4, ErrorMessage = "nhập tên danh mục")]
		public string name { get; set; }
		[Required, MinLength(4, ErrorMessage = "nhập mô tả danh mục")]
		public string description { get; set; }
	}
}
