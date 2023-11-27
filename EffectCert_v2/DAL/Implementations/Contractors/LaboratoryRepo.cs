using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class LaboratoryRepo : IRepository<Laboratory>
    {
        private readonly AppDBContext appDBContext;

        public LaboratoryRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<Laboratory>> GetAll()
        {
            return await appDBContext.Laboratories
                .Include(l => l.ContractorLegal)
                .Include(l => l.Attestate)
                .Select(l => new Laboratory
                {
                    Id = l.Id,
                    ShortName = l.ShortName,
                    AttestateId = l.AttestateId,
                    Attestate = new Attestate
                    {
                        Number = l.Attestate != null ? l.Attestate.Number : String.Empty,
                    },
                    ContractorLegalId = l.ContractorLegalId,
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = l.ContractorLegal.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<Laboratory> Get(int id)
        {
            return await appDBContext.Laboratories
                .Include(l => l.ContractorLegal)
                .Include(l => l.Attestate)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new Laboratory();
        }

        public async Task<ICollection<Laboratory>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.Laboratories
                .Include(l => l.ContractorLegal)
                .Include(l => l.Attestate)
                .Where(c => c.Name.Contains(searchStr) || c.ShortName.Contains(searchStr))
                .Select(l => new Laboratory
                {
                    Id = l.Id,
                    ShortName = l.ShortName,
                    AttestateId = l.AttestateId,
                    Attestate = new Attestate
                    {
                        Number = l.Attestate != null ? l.Attestate.Number : String.Empty,
                    },
                    ContractorLegalId = l.ContractorLegalId,
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = l.ContractorLegal.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<int> Create(Laboratory laboratory)
        {
            if (laboratory == null)
                return 0;

            appDBContext.Laboratories.Add(laboratory);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Laboratory laboratory)
        {
            if (laboratory == null)
                return 0;

            appDBContext.Laboratories.Update(laboratory);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Laboratory? laboratory = await appDBContext.Laboratories.FindAsync(id);
            if (laboratory == null)
                return 0;

            appDBContext.Laboratories.Remove(laboratory);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
