using ITMS.Model.Models;
using System;
using System.Linq;

namespace ITMS.Data.Interface
{
    public interface ICommonLookUpRepository
    {
        IQueryable<CommonLookUp> GetCommonLookUpList();
        void CreateCommonlookUp(CommonLookUp commonlookup);
        void UpdateCommonLookUp(CommonLookUp commonlookup);
        CommonLookUp GetCommonlookUpById(Guid id);
        void SaveChanges();
        bool CheckIfExist(string configName, string configKey, bool isFromUpdate = false, Guid id = default);
    }
}
