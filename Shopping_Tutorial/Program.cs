using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.Repository;
using Shopping_Tutorial.Service;


var builder = WebApplication.CreateBuilder(args);

// Đăng ký DataContext với DI container
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
});

// Đăng ký BrandService vào DI container
//builder.Services.AddScoped<BrandService>(); // Đảm bảo rằng BrandService đã được đăng ký

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<FeedBackService>();


// Cấu hình CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()   // Cho phép tất cả các nguồn
			   .AllowAnyMethod()   // Cho phép tất cả các phương thức HTTP (GET, POST, PUT, DELETE, ...)
			   .AllowAnyHeader();  // Cho phép tất cả các header
	});
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

// Kích hoạt CORS
app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();


app.Run();
