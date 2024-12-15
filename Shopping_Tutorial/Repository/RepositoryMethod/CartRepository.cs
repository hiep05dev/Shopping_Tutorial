using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.Repository.RepositoryMethod
{
	public interface CartRepository
	{
		public Task<object>InsertCart(CartRequest cartRequest);
		public Task<IEnumerable<CartModel>> GetAllCartByUserId(int userId);

		public Task<CartModel> DeleteCartById(int id);
	}
}
