﻿using EffectCert.DAL.Entities.Others;
using EffectCert.DAL.Implementations.Others;
using EffectCert.BLL;

namespace EffectCert.BLL.Others
{
    public class InconsistenceBLL : ICommonBLL<Inconsistence>
    {
        private readonly InconsistenceRepo inconsistenceDAL;

        public InconsistenceBLL(InconsistenceRepo inconsistenceDAL)
        {
            this.inconsistenceDAL = inconsistenceDAL;
        }

        public async Task<Inconsistence> Get(int id)
        {
            return await inconsistenceDAL.Get(id);
        }

        public async Task<int> UpdateOrCreate(Inconsistence inconsistence)
        {
            return inconsistence.Id == 0
                ? await inconsistenceDAL.Create(inconsistence)
                : await inconsistenceDAL.Update(inconsistence);
        }

        public async Task<IEnumerable<Inconsistence>> Find(string searchStr)
        {
            return await inconsistenceDAL.Find(searchStr);
        }
    }
}
