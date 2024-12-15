using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.Repository.RepositoryMethod
{
	public interface UserRepository
	{
		public Task<UserModel> Login(UserRequest userRequest);
	}
}
