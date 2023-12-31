using AutoMapper;
using BloggingAPI.Profiles;
using BloggingDomain.Interfaces;
using BloggingDomain.Services.AuthServices;
using BloggingDomain.Services.DbServices;
using BloggingInfrastructure.Data;
using BloggingInfrastructure.Interfaces;
using BloggingInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();
builder.Services.AddScoped<IDatabaseApiWrapper, DatabaseApiWrapper>();
builder.Services.AddScoped<IUserRespository, UserRespository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
