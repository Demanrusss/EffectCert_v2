﻿using Microsoft.EntityFrameworkCore;
using EffectCert.DAL.Entities.Contractors;
using EffectCert.DAL.Interfaces;
using EffectCert.DAL.DBContext;

namespace EffectCert.DAL.Implementations.Contractors
{
    public class ContractorIndividualRepo : IRepository<ContractorIndividual>
    {
        private readonly AppDBContext appDBContext;

        public ContractorIndividualRepo(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<ICollection<ContractorIndividual>> GetAll()
        {
            return await appDBContext.ContractorIndividuals.ToListAsync();
        }

        public async Task<ContractorIndividual> Get(int id)
        {
            return await appDBContext.ContractorIndividuals.FirstOrDefaultAsync(a => a.Id == id) ?? new ContractorIndividual();
        }

        public async Task<ICollection<ContractorIndividual>> Find(string searchStr)
        {
            if (String.IsNullOrWhiteSpace(searchStr))
                return await GetAll();

            return await appDBContext.ContractorIndividuals
                .Where(c => c.LastName.Contains(searchStr) || c.FirstName.Contains(searchStr))
                .ToListAsync();
        }

        public async Task<int> Create(ContractorIndividual contractorIndividual)
        {
            if (contractorIndividual == null)
                return 0;

            appDBContext.ContractorIndividuals.Add(contractorIndividual);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Update(ContractorIndividual contractorIndividual)
        {
            if (contractorIndividual == null)
                return 0;

            appDBContext.ContractorIndividuals.Update(contractorIndividual);
            return await appDBContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            ContractorIndividual? contractorIndividual = await appDBContext.ContractorIndividuals.FindAsync(id);
            if (contractorIndividual == null)
                return 0;

            appDBContext.ContractorIndividuals.Remove(contractorIndividual);
            return await appDBContext.SaveChangesAsync();
        }
    }
}
