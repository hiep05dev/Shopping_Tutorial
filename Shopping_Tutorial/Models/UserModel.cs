﻿using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
	}
}
