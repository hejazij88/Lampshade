using System.Text.Json.Serialization;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using _0_Framework.Infrastructure;
using AccountManagement.Configuration;
using BlogManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using DiscountManagerInfrastructure.Configuration;
using InventoryManagement.Api;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using ServiceHost;
using ShopManagement.Configuration;
using ShopManagement.Presentation.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("LampShade");

ShopManagementBootstrapper.Configure(builder.Services, connectionString);
DiscountManagerBootstrapper.Configure(builder.Services, connectionString);
InventoryManagementBootstrapper.Configure(builder.Services, connectionString);
BlogManagementBootstrapper.Configure(builder.Services, connectionString);
CommentManagementBootstrapper.Configure(builder.Services, connectionString);
AccountManagementBootstrapper.Configure(builder.Services, connectionString);

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IFileUploader, FileUploader>();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
          {
              o.LoginPath = new PathString("/Account");
              o.LogoutPath = new PathString("/Account");
              o.AccessDeniedPath = new PathString("/AccessDenied");
          });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea",
    builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

    options.AddPolicy("Shop",
    builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Discount",
    builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Account",
    builder => builder.RequireRole(new List<string> { Roles.Administrator }));
});

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
    builder
        .WithOrigins("https://localhost:5002")
        .AllowAnyHeader()
        .AllowAnyMethod()));

builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
        options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
    })
    .AddApplicationPart(typeof(ProductController).Assembly)
    .AddApplicationPart(typeof(InventoryController).Assembly)
    .AddNewtonsoftJson();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseCookiePolicy();


app.UseRouting();

app.UseAuthorization();
app.UseCors("MyPolicy");


app.MapStaticAssets();
app.MapRazorPages();
app.MapControllers();

app.Run();
