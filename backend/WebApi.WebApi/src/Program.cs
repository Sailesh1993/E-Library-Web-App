using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Business.src.Abstractions;
using WebApi.Business.src.Implementations;
using WebApi.Domain.src.Abstractions;
using WebApi.Domain.src.Entities;
using WebApi.WebApi.src.Database;
using WebApi.WebApi.src.RepoImplementation;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
var npgsqlBuilder = new NpgsqlDataSourceBuilder(connectionString);
npgsqlBuilder.MapEnum<Role>();
var modifiedConnectionString = npgsqlBuilder.Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.AddInterceptors(new TimeStampInterceptor());
    options.UseNpgsql(modifiedConnectionString)
           .UseSnakeCaseNamingConvention();
});

//Add AutoMapper DI
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add Service DI
builder.Services
.AddScoped<IUserRepo, UserRepo>()
.AddScoped<IUserService, UserService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
            Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
        });
        options.OperationFilter<SecurityRequirementsOperationFilter> ();
    });
//Config route
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

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
