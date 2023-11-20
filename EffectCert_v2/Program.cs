using Microsoft.EntityFrameworkCore;
using EffectCert.Configuration;
using EffectCert.DAL.DBContext;
using EffectCert.BLL.Contractors;
using EffectCert.DAL.Implementations.Contractors;
using EffectCert.BLL.Documents;
using EffectCert.DAL.Implementations.Documents;
using EffectCert.BLL.Main;
using EffectCert.DAL.Implementations.Main;
using EffectCert.BLL.Others;
using EffectCert.DAL.Implementations.Others;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.Bind("EffectCertProject", new Configuration());

// Add services to the container.
builder.Services.AddControllersWithViews();
// Contractors
builder.Services.AddScoped<AddressBLL, AddressBLL>();
builder.Services.AddScoped<AddressRepo, AddressRepo>();
builder.Services.AddScoped<AssessBodyBLL, AssessBodyBLL>();
builder.Services.AddScoped<AssessBodyRepo, AssessBodyRepo>();
builder.Services.AddScoped<AssessBodyEmployeeBLL, AssessBodyEmployeeBLL>();
builder.Services.AddScoped<AssessBodyEmployeeRepo, AssessBodyEmployeeRepo>();
builder.Services.AddScoped<BankAccountBLL, BankAccountBLL>();
builder.Services.AddScoped<BankAccountRepo, BankAccountRepo>();
builder.Services.AddScoped<ContractorIndividualBLL, ContractorIndividualBLL>();
builder.Services.AddScoped<ContractorIndividualRepo, ContractorIndividualRepo>();
builder.Services.AddScoped<ContractorLegalBLL, ContractorLegalBLL>();
builder.Services.AddScoped<ContractorLegalRepo, ContractorLegalRepo>();
builder.Services.AddScoped<ContractorLegalEmployeeBLL, ContractorLegalEmployeeBLL>();
builder.Services.AddScoped<ContractorLegalEmployeeRepo, ContractorLegalEmployeeRepo>();
builder.Services.AddScoped<LaboratoryBLL, LaboratoryBLL>();
builder.Services.AddScoped<LaboratoryRepo, LaboratoryRepo>();
builder.Services.AddScoped<LaboratoryEmployeeBLL, LaboratoryEmployeeBLL>();
builder.Services.AddScoped<LaboratoryEmployeeRepo, LaboratoryEmployeeRepo>();
// Documents
builder.Services.AddScoped<AttestateBLL, AttestateBLL>();
builder.Services.AddScoped<AttestateRepo, AttestateRepo>();
builder.Services.AddScoped<CertificateBLL, CertificateBLL>();
builder.Services.AddScoped<CertificateRepo, CertificateRepo>();
builder.Services.AddScoped<ContractBLL, ContractBLL>();
builder.Services.AddScoped<ContractRepo, ContractRepo>();
builder.Services.AddScoped<DeclarationBLL, DeclarationBLL>();
builder.Services.AddScoped<DeclarationRepo, DeclarationRepo>();
builder.Services.AddScoped<GovStandardBLL, GovStandardBLL>();
builder.Services.AddScoped<GovStandardRepo, GovStandardRepo>();
builder.Services.AddScoped<GTDBLL, GTDBLL>();
builder.Services.AddScoped<GTDRepo, GTDRepo>();
builder.Services.AddScoped<InvoiceBLL, InvoiceBLL>();
builder.Services.AddScoped<InvoiceRepo, InvoiceRepo>();
builder.Services.AddScoped<ManufacturerStandardBLL, ManufacturerStandardBLL>();
builder.Services.AddScoped<ManufacturerStandardRepo, ManufacturerStandardRepo>();
builder.Services.AddScoped<TechRegBLL, TechRegBLL>();
builder.Services.AddScoped<TechRegRepo, TechRegRepo>();
builder.Services.AddScoped<TestProtocolBLL, TestProtocolBLL>();
builder.Services.AddScoped<TestProtocolRepo, TestProtocolRepo>();
// Main
builder.Services.AddScoped<ActionPlanBLL, ActionPlanBLL>();
builder.Services.AddScoped<ActionPlanRepo, ActionPlanRepo>();
builder.Services.AddScoped<AppDecisionBLL, AppDecisionBLL>();
builder.Services.AddScoped<AppDecisionRepo, AppDecisionRepo>();
builder.Services.AddScoped<ApplicationBLL, ApplicationBLL>();
builder.Services.AddScoped<ApplicationRepo, ApplicationRepo>();
builder.Services.AddScoped<ExpertDecisionBLL, ExpertDecisionBLL>();
builder.Services.AddScoped<ExpertDecisionRepo, ExpertDecisionRepo>();
builder.Services.AddScoped<IssueDecisionBLL, IssueDecisionBLL>();
builder.Services.AddScoped<IssueDecisionRepo, IssueDecisionRepo>();
builder.Services.AddScoped<RecommendationBLL, RecommendationBLL>();
builder.Services.AddScoped<RecommendationRepo, RecommendationRepo>();
builder.Services.AddScoped<SelectProductsActBLL, SelectProductsActBLL>();
builder.Services.AddScoped<SelectProductsActRepo, SelectProductsActRepo>();
// Others
builder.Services.AddScoped<CertObjectBLL, CertObjectBLL>();
builder.Services.AddScoped<CertObjectRepo, CertObjectRepo>();
builder.Services.AddScoped<InconsistenceBLL, InconsistenceBLL>();
builder.Services.AddScoped<InconsistenceRepo, InconsistenceRepo>();
builder.Services.AddScoped<MeasurementUnitBLL, MeasurementUnitBLL>();
builder.Services.AddScoped<MeasurementUnitRepo, MeasurementUnitRepo>();
builder.Services.AddScoped<ProductBLL, ProductBLL>();
builder.Services.AddScoped<ProductRepo, ProductRepo>();
builder.Services.AddScoped<ProductQuantityBLL, ProductQuantityBLL>();
builder.Services.AddScoped<ProductQuantityRepo, ProductQuantityRepo>();
builder.Services.AddScoped<RequirementBLL, RequirementBLL>();
builder.Services.AddScoped<RequirementRepo, RequirementRepo>();
builder.Services.AddScoped<SchemaBLL, SchemaBLL>();
builder.Services.AddScoped<SchemaRepo, SchemaRepo>();
builder.Services.AddScoped<SelectedSampleQuantityBLL, SelectedSampleQuantityBLL>();
builder.Services.AddScoped<SelectedSampleQuantityRepo, SelectedSampleQuantityRepo>();
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
