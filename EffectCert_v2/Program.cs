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
using EffectCert.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.Bind("EffectCertProject", new Configuration());

// Add services to the container.
builder.Services.AddControllersWithViews();
// Contractors
builder.Services.AddScoped<IAddressBLL, AddressBLL>();
builder.Services.AddScoped<AddressRepo, AddressRepo>();
builder.Services.AddScoped<IAssessBodyBLL, AssessBodyBLL>();
builder.Services.AddScoped<AssessBodyRepo, AssessBodyRepo>();
builder.Services.AddScoped<IAssessBodyEmployeeBLL, AssessBodyEmployeeBLL>();
builder.Services.AddScoped<AssessBodyEmployeeRepo, AssessBodyEmployeeRepo>();
builder.Services.AddScoped<IBankAccountBLL, BankAccountBLL>();
builder.Services.AddScoped<BankAccountRepo, BankAccountRepo>();
builder.Services.AddScoped<IContractorIndividualBLL, ContractorIndividualBLL>();
builder.Services.AddScoped<ContractorIndividualRepo, ContractorIndividualRepo>();
builder.Services.AddScoped<IContractorLegalBLL, ContractorLegalBLL>();
builder.Services.AddScoped<ContractorLegalRepo, ContractorLegalRepo>();
builder.Services.AddScoped<IContractorLegalEmployeeBLL, ContractorLegalEmployeeBLL>();
builder.Services.AddScoped<ContractorLegalEmployeeRepo, ContractorLegalEmployeeRepo>();
builder.Services.AddScoped<ILaboratoryBLL, LaboratoryBLL>();
builder.Services.AddScoped<LaboratoryRepo, LaboratoryRepo>();
builder.Services.AddScoped<ILaboratoryEmployeeBLL, LaboratoryEmployeeBLL>();
builder.Services.AddScoped<LaboratoryEmployeeRepo, LaboratoryEmployeeRepo>();
// Documents
builder.Services.AddScoped<IAttestateBLL, AttestateBLL>();
builder.Services.AddScoped<AttestateRepo, AttestateRepo>();
builder.Services.AddScoped<ICertificateBLL, CertificateBLL>();
builder.Services.AddScoped<CertificateRepo, CertificateRepo>();
builder.Services.AddScoped<IContractBLL, ContractBLL>();
builder.Services.AddScoped<ContractRepo, ContractRepo>();
builder.Services.AddScoped<IDeclarationBLL, DeclarationBLL>();
builder.Services.AddScoped<DeclarationRepo, DeclarationRepo>();
builder.Services.AddScoped<IGovStandardBLL, GovStandardBLL>();
builder.Services.AddScoped<GovStandardRepo, GovStandardRepo>();
builder.Services.AddScoped<IGTDBLL, GTDBLL>();
builder.Services.AddScoped<GTDRepo, GTDRepo>();
builder.Services.AddScoped<IInvoiceBLL, InvoiceBLL>();
builder.Services.AddScoped<InvoiceRepo, InvoiceRepo>();
builder.Services.AddScoped<IManufacturerStandardBLL, ManufacturerStandardBLL>();
builder.Services.AddScoped<ManufacturerStandardRepo, ManufacturerStandardRepo>();
builder.Services.AddScoped<ITechRegBLL, TechRegBLL>();
builder.Services.AddScoped<TechRegRepo, TechRegRepo>();
builder.Services.AddScoped<ITestProtocolBLL, TestProtocolBLL>();
builder.Services.AddScoped<TestProtocolRepo, TestProtocolRepo>();
// Main
builder.Services.AddScoped<IActionPlanBLL, ActionPlanBLL>();
builder.Services.AddScoped<ActionPlanRepo, ActionPlanRepo>();
builder.Services.AddScoped<IAppDecisionBLL, AppDecisionBLL>();
builder.Services.AddScoped<AppDecisionRepo, AppDecisionRepo>();
builder.Services.AddScoped<IApplicationBLL, ApplicationBLL>();
builder.Services.AddScoped<ApplicationRepo, ApplicationRepo>();
builder.Services.AddScoped<IExpertDecisionBLL, ExpertDecisionBLL>();
builder.Services.AddScoped<ExpertDecisionRepo, ExpertDecisionRepo>();
builder.Services.AddScoped<IIssueDecisionBLL, IssueDecisionBLL>();
builder.Services.AddScoped<IssueDecisionRepo, IssueDecisionRepo>();
builder.Services.AddScoped<IRecommendationBLL, RecommendationBLL>();
builder.Services.AddScoped<RecommendationRepo, RecommendationRepo>();
builder.Services.AddScoped<ISelectProductsActBLL, SelectProductsActBLL>();
builder.Services.AddScoped<SelectProductsActRepo, SelectProductsActRepo>();
// Others
builder.Services.AddScoped<ICertObjectBLL, CertObjectBLL>();
builder.Services.AddScoped<CertObjectRepo, CertObjectRepo>();
builder.Services.AddScoped<IInconsistenceBLL, InconsistenceBLL>();
builder.Services.AddScoped<InconsistenceRepo, InconsistenceRepo>();
builder.Services.AddScoped<IMeasurementUnitBLL, MeasurementUnitBLL>();
builder.Services.AddScoped<MeasurementUnitRepo, MeasurementUnitRepo>();
builder.Services.AddScoped<IProductBLL, ProductBLL>();
builder.Services.AddScoped<ProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductQuantityBLL, ProductQuantityBLL>();
builder.Services.AddScoped<ProductQuantityRepo, ProductQuantityRepo>();
builder.Services.AddScoped<IRequirementBLL, RequirementBLL>();
builder.Services.AddScoped<RequirementRepo, RequirementRepo>();
builder.Services.AddScoped<ISchemaBLL, SchemaBLL>();
builder.Services.AddScoped<SchemaRepo, SchemaRepo>();
builder.Services.AddScoped<ISelectedSampleQuantityBLL, SelectedSampleQuantityBLL>();
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
