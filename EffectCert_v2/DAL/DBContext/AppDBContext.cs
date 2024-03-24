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
        public DbSet<GovStandardParagraphs> GovStandardsParagraphs { get; set; }
        public DbSet<GTD> GTDs { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Attestate> Attestates { get; set; }
        public DbSet<ManufacturerStandard> ManufacturerStandards { get; set; }
        public DbSet<TechReg> TechRegs { get; set; }
        public DbSet<TechRegParagraphs> TechRegsParagraphs { get; set; }
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

        // Many to many
        public DbSet<ApplicationsProducts> ApplicationsProducts { get; set; }
        public DbSet<ApplicationsProductQuantities> ApplicationsProductQuantities { get; set; }
        public DbSet<SchemasCertObjects> SchemasCertObjects { get; set; }
        public DbSet<ApplicationsContracts> ApplicationsContracts { get; set; }
        public DbSet<ApplicationsGTDs> ApplicationsGTDs { get; set; }
        public DbSet<ApplicationsInvoices> ApplicationsInvoices { get; set; }
        public DbSet<ApplicationsTechRegsParagraphs> ApplicationsTechRegsParagraphs { get; set; }
        public DbSet<ApplicationsGovStandardsParagraphs> ApplicationsGovStandardsParagraphs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>()
                .HasMany(a => a.Products)
                .WithMany(p => p.Applications)
                .UsingEntity<ApplicationsProducts>();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.ProductQuantities)
                .WithMany(pq => pq.Applications)
                .UsingEntity<ApplicationsProductQuantities>();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.Contracts)
                .WithMany(c => c.Applications)
                .UsingEntity<ApplicationsContracts>();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.GTDs)
                .WithMany(c => c.Applications)
                .UsingEntity<ApplicationsGTDs>();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.Invoices)
                .WithMany(c => c.Applications)
                .UsingEntity<ApplicationsInvoices>();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.TechRegsParagraphs)
                .WithMany(tr => tr.Applications)
                .UsingEntity<ApplicationsTechRegsParagraphs>();

            modelBuilder.Entity<Application>()
                .HasMany(a => a.GovStandardsParagraphs)
                .WithMany(gs => gs.Applications)
                .UsingEntity<ApplicationsGovStandardsParagraphs>();

            modelBuilder.Entity<ExpertDecision>()
                .HasMany(ed => ed.TestProtocols)
                .WithMany(tp => tp.ExpertDecisions)
                .UsingEntity<ExpertDecisionsTestProtocols>();

            modelBuilder.Entity<SelectProductsAct>()
                .HasMany(spa => spa.SelectedProducts)
                .WithMany(sp => sp.SelectProductsActs)
                .UsingEntity<SelectProductsActsSelectedSampleQuantities>();

            modelBuilder.Entity<Schema>()
                .HasMany(s => s.CertObjects)
                .WithMany(co => co.Schemas)
                .UsingEntity<SchemasCertObjects>();
        }
    }
}