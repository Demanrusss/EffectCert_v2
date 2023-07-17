using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Entities.Documents;
using EffectCert.DAL.Entities.Main;
using EffectCert.DAL.Entities.Others;

namespace EffectCert.DAL.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        // Contractors
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AssessBody> AssessBodies { get; set; }
        public DbSet<AssessBodyEmployee> AssessBodyEmployees { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ContractorLegalEmployee> ContractorLegalEmployees { get; set; }
        public DbSet<ContractorIndividual> ContractorIndividuals { get; set; }
        public DbSet<ContractorLegal> ContractorLegals { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<LaboratoryEmployee> LaboratoryEmployees { get; set; }

        // Documents
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<GovStandard> GovStandards { get; set; }
        public DbSet<GTD> GTDs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Attestate> Attestates { get; set; }
        public DbSet<ManufacturerStandard> ManufacturerStandards { get; set; }
        public DbSet<TechReg> TechRegs { get; set; }
        public DbSet<TestProtocol> TestProtocols { get; set; }

        // Others
        public DbSet<CertObject> CertObjects { get; set; }
        public DbSet<Inconsistence> Inconsistences { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Schema> Schemas { get; set; }
        public DbSet<SelectedSampleQuantity> SelectedSampleQuantities { get; set; }
        public DbSet<ProductQuantity> ProductQuantities { get; set; }

        // Official documents
        public DbSet<ActionPlan> ActionPlans { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<IssueDecision> IssueDecisions { get; set; }
        public DbSet<AppDecision> AppDecisions { get; set; }
        public DbSet<ExpertDecision> ExpertDecisions { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<SelectProductsAct> SelectProductsActs { get; set; }
    }
}