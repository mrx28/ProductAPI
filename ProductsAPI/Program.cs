using NLog.Web;
using ProductsAPI;
using ProductsAPI.Entities;
using ProductsAPI.Interfaces;
using ProductsAPI.Repositories;
using ProductsAPI.Services;

var logger = NLog.LogManager.GetCurrentClassLogger();
logger.Debug("init main");


try
{


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICrudOperation<Product>, ProductRepository>();
builder.Services.AddScoped<Seeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddScoped<ErrorHandligMiddleware>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseNLog();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandligMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "Stopper program becouse throw exception!");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}