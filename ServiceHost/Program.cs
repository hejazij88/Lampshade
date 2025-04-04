using _0_Framework.Application;
using BlogManagement.Infrastructure.Configuration;
using DiscountManagerInfrastructure.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using ServiceHost;
using ShopManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LampShade");

ShopManagementBootstrapper.Configure(builder.Services, connectionString);
DiscountManagerBootstrapper.Configure(builder.Services, connectionString);
InventoryManagementBootstrapper.Configure(builder.Services, connectionString);
BlogManagementBootstrapper.Configure(builder.Services, connectionString);


builder.Services.AddTransient<IFileUploader, FileUploader>();


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

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
