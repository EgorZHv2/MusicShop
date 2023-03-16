using Microsoft.AspNetCore.Identity;
using MusicShop.Infrastructure.Identity;
using MusicShop.Persistance.Contexts;
using MusicShop.Domain.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseNpgsql("Host = localhost;Port = 5432; Database = MusicShopDB; UserId = postgres; Password = 1385620;"));
builder.Services.AddIdentity<UserEntity, IdentityRole<Guid>>().AddEntityFrameworkStores<AppIdentityDbContext>();


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
