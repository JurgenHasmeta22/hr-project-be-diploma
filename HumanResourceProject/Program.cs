global using HumanResourceProject;
using DAL.Contracts;
using DAL.Concrete;
using DI;
using Domain.Mappings;
using Entities.Models;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using Domain.Concrete;
using HumanResourceProject.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("RecrutimentDatabase");
builder.Services.AddDbContext<HRDBContext>(options => options.UseSqlServer(connString));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("JWT Bearer", new OpenApiSecurityScheme {
        Description = "Authorization scheme with JWT tokens.",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAutoMapper(typeof(GeneralProfile));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});

builder.Services.AddIdentityServices(builder.Configuration);

// use Lamar as DI.
builder.Host.UseLamar((context, registry) =>
{
    // register services using Lamar
    registry.IncludeRegistry<RecrutimentRegistry>();
    registry.IncludeRegistry<MapperRegistry>();
    // add the controllers
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
