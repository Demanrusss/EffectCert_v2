﻿using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

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
                    .ThenInclude(cl => cl.BankAccount)
                .ToListAsync();
        }

        public async Task<AssessBody> Get(int id)
        {
            return await appDBContext.AssessBodies
                .Include(ab => ab.Address)
                .Include(ab => ab.Attestate)
                .Include(ab => ab.ContractorLegal)
                    .ThenInclude(cl => cl.BankAccount)
                .FirstOrDefaultAsync(a => a.Id == id) ?? new AssessBody();
        }

        public async Task<ICollection<AssessBody>> Find(string searchStr = "")
        {
            var result = appDBContext.AssessBodies.Where(c => c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(AssessBody assessBody)
        {
            if (assessBody == null)
                throw new ArgumentNullException();

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
