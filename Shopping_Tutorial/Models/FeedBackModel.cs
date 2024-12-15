using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.Models
{
	public class FeedBackModel
	{
		[Key]
		public int Id { get; set; }

		public int UserId { get; set; }

		public string Comment { get; set; }

		public UserModel User { get; set; }
	}
}
