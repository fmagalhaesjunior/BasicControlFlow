using BasicControlFlow.Domain.Interfaces;
using BasicControlFlow.Infrastructure.Data;
using BasicControlFlow.Infrastructure.Repositories;
using BasicControlFlow.Web.DependencyInjection.Scoped;
using BasicControlFlow.Web.DependencyInjection.Singleton;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Singleton
builder.Services.AddSingleton<ILogService, LogService>();

// Scoped
builder.Services.AddScoped<IDataService, DataService>();

// Repositórios e DbContext
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Aplica as migrations no startup
}

