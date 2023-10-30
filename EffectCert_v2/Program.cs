using Microsoft.EntityFrameworkCore;
using EffectCert.Configuration;
using EffectCert.DAL.DBContext;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Implementations.Contractors;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.Bind("EffectCertProject", new Configuration());

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AddressBLL, AddressBLL>();
builder.Services.AddScoped<AddressRepo, AddressRepo>();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
