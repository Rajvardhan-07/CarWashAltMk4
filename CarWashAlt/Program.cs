using CarWashAlt.Context;
using CarWashAlt.Interfaces;
using CarWashAlt.Models;
using CarWashAlt.Repositories;
using CarWashAlt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<CarWashAltDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("CarWashAltConnectionString"));
});


builder.Services.AddScoped<IUserData, UserDetailRepository>();
builder.Services.AddScoped<UserDetailService, UserDetailService>();

builder.Services.AddScoped<IOrderData, OrderDataRepository>();
builder.Services.AddScoped<OrderDataService, OrderDataService>();

builder.Services.AddScoped<ICar, CarRepository>();
builder.Services.AddScoped<CarService, CarService>();

builder.Services.AddScoped<IRating, RatingRepository>();
builder.Services.AddScoped<RatingService, RatingService>();

builder.Services.AddScoped<IPackage, PackageRepository>();
builder.Services.AddScoped<PackageService, PackageService>();


builder.Services.AddScoped<IAddress, AddressRepository>();
builder.Services.AddScoped<AddressService, AddressService>();

builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<OrderService, OrderService>();

builder.Services.AddScoped<IPayment, PaymentRepository>();
builder.Services.AddScoped<PaymentService, PaymentService>();




builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This Will Be Used To Generate Tokens For The Project")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero   // to change default time 5 minute
    };

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AnyOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
