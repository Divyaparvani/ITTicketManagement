using ITMS.Data.Infrastructure;
using ITMS.Data.Interface;
using ITMS.Model.Models;
using System;
using System.Linq;

namespace ITMS.Data.Repository
{
    public class CommonLookUpRepository : Repository<CommonLookUp>, ICommonLookUpRepository
    {
        public DataContext context;
        public CommonLookUpRepository(DataContext Context) : base(Context)
        {
            context = Context;
        }

        public IQueryable<CommonLookUp> GetCommonLookUpList()
        {
            return GetWithWhere(x => !x.IsDeleted);
        }
        public void CreateCommonlookUp(CommonLookUp commonlookup)
        {
            Add(commonlookup);
        }
        public CommonLookUp GetCommonlookUpById(Guid id)
        {
            return GetById(id);
        }
        public void UpdateCommonLookUp(CommonLookUp commonlookup)
        {
            Update(commonlookup);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public bool CheckIfExist(string configName, string configKey, bool isFromUpdate = false, Guid id = default)
        {
            return GetWithWhere(x => x.ConfigKey == configKey && x.ConfigName == configName &&((isFromUpdate && x.Id != id) || !isFromUpdate) && !x.IsDeleted).Any();
        }
    }
}
