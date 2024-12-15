using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Service;

namespace Shopping_Tutorial.Controllers
{
	[ApiController]
	[Route("api/product")]
	public class ProductController:ControllerBase
	{
       private ProductService productService;

		public ProductController(ProductService productService)
		{
			this.productService = productService;
		}

		[HttpPost ("insert-product")]
		[AllowAnonymous]
		public async Task<IActionResult> InsertProduct([FromForm] ProductRequest productRequest)
		{
			var product = await productService.InsertProduct(productRequest);
			return Ok(product);
		}


		[HttpGet("get-all-product")]
	
		public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProduct()
		{
			var  product = await productService.GetAllProduct();

			return Ok(product);
		}


		[HttpGet("by-name-category")]
	
		public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProductByCategoryName([FromQuery] string categoryName)
		{
           var product = await productService.GetAllProductByCategoryName(categoryName);

			return Ok(product);
		}

		[HttpGet("get-product-by-id")]
		
		public async Task<ActionResult> GetProductById ([FromQuery] int id)
		{
			var product = await productService.GetProductById(id);
			return Ok(product);
		}

		[HttpPut("update-size-and-color")]
		public async Task<ActionResult> UpdateSizeAndColor([FromBody] ProductUpdateRequest productUpdateRequest)
		{
			var product = await productService.UpdateSizeAndColor(productUpdateRequest);
			return Ok(product);
		}
	}
}
