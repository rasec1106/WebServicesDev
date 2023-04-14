using ApiProduct;
using ApiProduct.DbContexts;
using ApiProduct.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

/**************************/
// Register database sql connection
var connectionString = builder.Configuration.GetConnectionString("ProductDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Register automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper); // using singleton patron ... to let it live in memory!!!
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // this line is needed... read the documentation

// Dependency Injection for IProductRepository
builder.Services.AddScoped<IProductRepository, ProductSQLRepository>();
/**************************/

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
