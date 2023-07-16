using System.Net;
using Microsoft.EntityFrameworkCore;
using API.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Also called dependancy injection container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle generates the content
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db service (this is a Lambda fuct)
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline. (Middleware order is  always important)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
