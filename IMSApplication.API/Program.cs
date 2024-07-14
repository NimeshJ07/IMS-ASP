using IMSApllication.Data;
using IMSApplication.IRespository;
using IMSApplication.IServices;
using IMSApplication.Respository;
using IMSApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
var connStr = config.GetConnectionString("connStr");

builder.Services.AddDbContext<IMSDbContext>(opt => opt.UseSqlServer(connStr, b => b.MigrationsAssembly("IMSApplication.API")));
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersServices, OrdersServices>();

builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<IOrderDetailsServices, OrderDetailsServices>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
