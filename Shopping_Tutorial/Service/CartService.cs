using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Repository;
using Shopping_Tutorial.Repository.RepositoryMethod;

namespace Shopping_Tutorial.Service
{
	public class CartService:CartRepository
	{
		private readonly DataContext _dataContext;

		public CartService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<CartModel> DeleteCartById(int id)
		{
			var cart = await _dataContext.Carts.FindAsync(id);

			_dataContext.Carts.Remove(cart);
			await _dataContext.SaveChangesAsync();	
			return cart;
		}

		public async Task<IEnumerable<CartModel>> GetAllCartByUserId(int userId)
		{
			return await _dataContext.Carts
				.Where(c => c.UserId == userId)
				.Include(c => c.Product)
				.Include(c => c.User)
				.ToListAsync();
		}

		public async Task<object> InsertCart(CartRequest cartRequest)
		{
			// Lấy thông tin sản phẩm từ cơ sở dữ liệu
			var product = await _dataContext.Products
				.Include(p => p.Category) // Bao gồm thông tin danh mục sản phẩm
				.FirstOrDefaultAsync(p => p.id == cartRequest.ProductId);

			// Lấy thông tin người dùng từ cơ sở dữ liệu
			var user = await _dataContext.Users
				.FirstOrDefaultAsync(u => u.Id == cartRequest.UserId);

			// Kiểm tra nếu sản phẩm hoặc người dùng không tồn tại
			if (product == null || user == null)
			{
				return new { message = "Product or User not found" }; // Trả về lỗi nếu không tìm thấy
			}

			// Tạo giỏ hàng mới
			var cart = new CartModel
			{
				ProductId = cartRequest.ProductId,
				UserId = cartRequest.UserId,
				Quantity = cartRequest.Quantity
			};

			// Thêm giỏ hàng vào cơ sở dữ liệu
			_dataContext.Carts.Add(cart);
			await _dataContext.SaveChangesAsync();

			// Trả về thông tin giỏ hàng, sản phẩm, và người dùng
			return new
			{
				Cart = new
				{
					cart.ProductId,
					cart.UserId,
					cart.Quantity,
					Product = new
					{
						product.id,
						product.name,
						product.description,
						product.price,
						product.size,
						product.color,
						product.stock,
						product.imgae,
						Category = new
						{
							product.Category.id,
							product.Category.name,
							product.Category.description
						}
					},
					User = new
					{
						user.Id,
						user.Name,
						user.Email,
						user.Phone
					}
				}
			};
		}
	}
}
