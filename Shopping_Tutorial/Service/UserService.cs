using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Repository;
using Shopping_Tutorial.Repository.RepositoryMethod;

namespace Shopping_Tutorial.Service
{
	public class UserService : UserRepository
	{
		private readonly DataContext _context;

		
		public UserService(DataContext context)
		{
			_context = context;
		}

		public async Task<UserModel> Login(UserRequest userRequest)
		{
			// Truy vấn tìm người dùng có email và mật khẩu khớp
			var user = await _context.Users
									  .FirstOrDefaultAsync(u => u.Email == userRequest.Email && u.Password == userRequest.Password);

			// Kiểm tra nếu không tìm thấy người dùng
			if (user == null)
			{
				// Trả về null nếu không tìm thấy người dùng
				return null;
			}

			// Trả về đối tượng người dùng tìm thấy
			return user;
		}
	}
}
