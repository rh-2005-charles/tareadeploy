using ic_tienda_bussines.Repositories;
using ic_tienda_bussines.Services;
using ic_tienda_data.Repositories;
using ic_tienda_data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

string connStr = builder.Configuration
   .GetValue<string>("ConnectionStrings:IcTiendaDb");

builder.Services.AddDbContext<ic_tienda_data.Sources.Data.IcTiendaDbContext>(
    // Connect to SqlServer
    //(config) => config.UseSqlServer(connStr, b => b.MigrationsAssembly("ic_tienda_presentacion"))
    // connect to sqlite database
    /* (config) => config.UseSqlite(
        builder.Configuration.GetConnectionString("IcLocalDb"),
         b => b.MigrationsAssembly("ic_tienda_presentation")
     ) */
    //Connect to MySql
    (config) => config.UseMySQL(connStr, b => b.MigrationsAssembly("ic_tienda_presentation"))

);


//Inyeccion de Dependencias
//para producto
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
//para categoria
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
