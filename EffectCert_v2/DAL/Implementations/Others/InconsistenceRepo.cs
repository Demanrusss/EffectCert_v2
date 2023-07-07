﻿using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Others
{
    public class InconsistenceRepo : IRepository<Inconsistence>
    {
        private readonly AppDBContext appDBContext;

        public InconsistenceRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<IEnumerable<Inconsistence>> GetAll()
        {
            return await appDBContext.Inconsistences.ToListAsync();
        }

        public async Task<Inconsistence> Get(int id)
        {
            return await appDBContext.Inconsistences.FirstOrDefaultAsync(a => a.Id == id) ?? new Inconsistence();
        }

        public async Task<IEnumerable<Inconsistence>> Find(string searchStr = "")
        {
            var result = appDBContext.Inconsistences.Where(c => c.Name.Contains(searchStr));
            return await result.ToListAsync();
        }

        public async Task<int> Create(Inconsistence inconsistence)
        {
            if (inconsistence == null)
                throw new ArgumentNullException();

            appDBContext.Inconsistences.Add(inconsistence);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(Inconsistence inconsistence)
        {
            if (inconsistence == null)
                return 0;

            appDBContext.Inconsistences.Update(inconsistence);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            Inconsistence? inconsistence = await appDBContext.Inconsistences.FindAsync(id);
            if (inconsistence == null)
                return 0;

            appDBContext.Inconsistences.Remove(inconsistence);

            return await appDBContext.SaveChangesAsync();
        }
    }
}
