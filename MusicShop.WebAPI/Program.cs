using Microsoft.AspNetCore.Identity;
using MusicShop.Persistance.Contexts;
using MusicShop.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql("Host = localhost;Port = 5432; Database = MusicShopDB; UserId = postgres; Password = 1385620;");
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//using(var scope = app.Services.CreateScope())
//{
//    var provider = scope.ServiceProvider;
//    var context = provider.GetRequiredService<ApplicationDbContext>();
//    context.Database.EnsureDeleted();
//    context.Database.EnsureCreated();
//}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
