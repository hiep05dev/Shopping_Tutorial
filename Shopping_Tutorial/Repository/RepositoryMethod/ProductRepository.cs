using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.Repository.RepositoryMethod
{
	public interface ProductRepository
	{
		public Task<ProductModel> InsertProduct(ProductRequest productRequest);
		public Task<IEnumerable<ProductModel>> GetAllProduct();

		public Task<IEnumerable<ProductModel>> GetAllProductByCategoryName(string categoryName);

		public Task<ProductModel> GetProductById(int id);

		public Task<ProductModel> UpdateSizeAndColor(ProductUpdateRequest productUpdateRequest);

		
	}
}
