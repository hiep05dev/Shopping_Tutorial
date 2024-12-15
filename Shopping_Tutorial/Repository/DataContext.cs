using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.Repository
{
	public class DataContext : DbContext

	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{ 
		}
		public DbSet<ProductModel> Products { get; set; }
		public DbSet<CategoryModel> Categorys { get; set; }
	    public DbSet<UserModel> Users { get; set; }
	    public DbSet<CartModel> Carts { get; set; }
		public DbSet<FeedBackModel> FeedBacks { get; set; }
	}
	
}
