using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;
using EffectCert.DAL.Entities.Documents;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class AssessBodyRepo : IRepository<AssessBody>
    {
        private readonly AppDBContext appDBContext;

        public AssessBodyRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<AssessBody>> GetAll()
        {
            return await appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                .Select(ab => new AssessBody
                {
                    Id = ab.Id,
                    Name = ab.Name,
                    ShortName = ab.ShortName,
                    AddressId = ab.AddressId,
                    AttestateId = ab.AttestateId,
                    ContractorLegalId = ab.ContractorLegalId,
                    Address = new Address
                    {
                        AddressStr = ab.Address.AddressStr,
                        Country = ab.Address.Country
                    },
                    Attestate = new Attestate
                    {
                        Number = ab.Attestate.Number
                    },
                    ContractorLegal = new ContractorLegal
                    {
                        ShortName = ab.ContractorLegal.ShortName
                    }
                })
                .ToListAsync();
        }

        public async Task<AssessBody> Get(int id)
        {
            return await appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new AssessBody();
        }

        public async Task<ICollection<AssessBody>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            var result = appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                .Where(c => c.Name.Contains(searchStr) || c.ShortName.Contains(searchStr));

            return await result.ToListAsync();
        }

        public async Task<int> Create(AssessBody assessBody)
        {
            if (assessBody == null)
                return 0;

            appDBContext.AssessBodies.Add(assessBody);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(AssessBody assessBody)
        {
            if (assessBody == null)
                return 0;

            appDBContext.AssessBodies.Update(assessBody);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            AssessBody? assessBody = await appDBContext.AssessBodies.FindAsync(id);
            if (assessBody == null)
                return 0;

            appDBContext.AssessBodies.Remove(assessBody);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
