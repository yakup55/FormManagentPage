using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CoreLayer.Configuration;
using CoreLayer.Model;
using CoreLayer.Repository;
using CoreLayer.Service;
using FormManagentProject.Filters;
using FormManagentProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Repository;
using ServiceLayer.MapProfile;
using ServiceLayer.Service;
using SharedLibrayLayer;
using SharedLibrayLayer.Configuration;
using SharedLibrayLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressConsumesConstraintForFormFileParameters = true;
});

builder.Services.AddScoped(typeof(NotFoundFilter<,>));
builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder =>
{
    containerbuilder.RegisterModule(new RepoServiceModel());
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormService, FormService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), opt =>
    {
        opt.MigrationsAssembly("RepositoryLayer");
    });
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
{
    opt.TokenLifespan = TimeSpan.FromHours(2);
});

builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddIdentity<UserApp, IdentityRole>(opt =>
{
    //Sifre sartlari
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz123456789_";
    opt.Password.RequiredLength = 8;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireDigit = false;

    //Kilit kismi
    //opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    //opt.Lockout.MaxFailedAccessAttempts = 3;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.UserCustomValidationResponse();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOption"));
builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));


var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();
builder.Services.AddCustomTokenAuth(tokenOptions, builder.Configuration);



builder.Services.ConfigureApplicationCookie(app =>
{
    var cookieBuilder = new CookieBuilder();
    cookieBuilder.Name = "test";
    app.Cookie = cookieBuilder;
    app.ExpireTimeSpan = TimeSpan.FromDays(2);
    app.SlidingExpiration = true;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCustomException();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();


app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
