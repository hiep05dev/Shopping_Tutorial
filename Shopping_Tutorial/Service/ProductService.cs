using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Repository;
using Shopping_Tutorial.Repository.RepositoryMethod;

namespace Shopping_Tutorial.Service
{

	public class ProductService : ProductRepository

	{
		private readonly DataContext _context;

		public ProductService(DataContext context)
		{
			_context = context;
		}
		//IEnumerable trả về 1 list
		public async Task<IEnumerable<ProductModel>> GetAllProduct()
		{
			return await _context.Products.Include(p => p.Category).ToListAsync();
		}

		public async Task<IEnumerable<ProductModel>> GetAllProductByCategoryName(string categoryName)
		{
			var product = await _context.Products.Where(p => p.Category.name == categoryName).ToListAsync();
			return product;
		}

		public async Task<ProductModel> GetProductById(int id)
		{
			var product = await _context.Products .Include(p => p.Category).FirstOrDefaultAsync(p => p.id == id);

			return product;
		}

		// chỉ có Task<ProductModel> trả về 1 đối tượng cụ thể
		public async Task<ProductModel> InsertProduct(ProductRequest productRequest)
		{
			byte[] imageData = null;
			using (var ms = new MemoryStream())
			{
				await productRequest.Image.CopyToAsync(ms);
				imageData = ms.ToArray();
			}
			var product = new ProductModel
			{
				name = productRequest.Name,
				description = productRequest.Description,
				price = productRequest.Price,
				size = productRequest.Size,
				color = productRequest.Color,
				stock = productRequest.Stock,
				imgae = imageData,
				CategoryId = productRequest.CategoryId
			};
			 
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
            return product;
		}

		public async Task<ProductModel> UpdateSizeAndColor(ProductUpdateRequest productUpdateRequest)
		{
			var product = await _context.Products.FindAsync(productUpdateRequest.Id);
			product.size = productUpdateRequest.Size;
			product.color = productUpdateRequest.Color;
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
			return product;

			
		}

		
	}
}
