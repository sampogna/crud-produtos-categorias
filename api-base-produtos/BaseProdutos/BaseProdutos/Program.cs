using BaseProdutos;
using BaseProdutos.Models;
using BaseProdutos.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// TODO: put the connection string somewhere better :)
var connectionString = "server=bsqlnpuzvdf6h32xq0ae-mysql.services.clever-cloud.com;user=u5lcfw91othege9j;password=UNU11Y6WZdwgcYy7o0c5;database=bsqlnpuzvdf6h32xq0ae";
//var serverVersion = new MySqlServerVersion(new Version(5, 7, 33));
var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql");
builder.Services.AddDbContext<bsqlnpuzvdf6h32xq0aeContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
