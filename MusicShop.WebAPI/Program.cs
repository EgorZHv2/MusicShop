using Microsoft.AspNetCore.Identity;
using MusicShop.Persistance.Contexts;
using MusicShop.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.WebAPI.Middleware;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using MusicShop.Domain.Resources.Localizations;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Identity.Client;
using MusicShop.Domain.Options.Configurations;
using MusicShop.WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization();
builder.Services.AddControllers()
    .AddMvcLocalization()
    .AddNewtonsoftJson();

  

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var basePath = AppContext.BaseDirectory;
    var xmlpath = Path.Combine(basePath, "WebAPI.xml");
    c.IncludeXmlComments(xmlpath);
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Description =
                @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
        }
    );
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new[] { string.Empty }
            }
        }
    );
});

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAppOptions(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var jwtConfiguration  = builder.Configuration
    .GetSection("JwtTokenConfiguration")
    .Get<JwtTokenConfiguration>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.JwtAuthKey)),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var context = provider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru"),
                SupportedCultures = new[] {new CultureInfo("en"),new CultureInfo("ru")},
                SupportedUICultures = new[] {new CultureInfo("en"),new CultureInfo("ru")}
            });

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<UserCheckMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "files"))) 
{
    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "files"));
}
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files")),
    RequestPath = new PathString( "/static")
});

app.Run();
