using Microsoft.EntityFrameworkCore;
using ProductApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProductContext>(options =>
{

if (builder.Environment.IsDevelopment())
{
var folder =Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbPath = System.IO.Path.Join(path, "AmcProducts.db");
options.UseSqlite($"Data Source = {dbPath}");
options.EnableDetailedErrors();
options.EnableSensitiveDataLogging();

}
else
{
    var cs = builder.Configuration.GetConnectionString("ProductsContext");
    options.UseSqlServer(cs);
}
});

//register repo
if (builder.Environment.IsDevelopment()){
    builder.Services.AddScoped<IProductRepo, FakeProductRepo>();
}
else {
    builder.Services.AddScoped<IProductRepo, ProductRepo>();
}

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//
