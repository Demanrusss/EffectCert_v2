using Microsoft.EntityFrameworkCore;
using EffectCert.Configuration;
using EffectCert.DAL.DBContext;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL.Documents;
using EffectCert.DAL.Implementations.Documents;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.Bind("EffectCertProject", new Configuration());

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AddressBLL, AddressBLL>();
builder.Services.AddScoped<AddressRepo, AddressRepo>();
builder.Services.AddScoped<AssessBodyBLL, AssessBodyBLL>();
builder.Services.AddScoped<AssessBodyRepo, AssessBodyRepo>();
builder.Services.AddScoped<AttestateBLL, AttestateBLL>();
builder.Services.AddScoped<AttestateRepo, AttestateRepo>();
builder.Services.AddScoped<ContractorLegalBLL, ContractorLegalBLL>();
builder.Services.AddScoped<ContractorLegalRepo, ContractorLegalRepo>();
builder.Services.AddScoped<AssessBodyEmployeeBLL, AssessBodyEmployeeBLL>();
builder.Services.AddScoped<AssessBodyEmployeeRepo, AssessBodyEmployeeRepo>();
builder.Services.AddScoped<ContractorLegalEmployeeBLL, ContractorLegalEmployeeBLL>();
builder.Services.AddScoped<ContractorLegalEmployeeRepo, ContractorLegalEmployeeRepo>();
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
