using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using System;
using System.Collections.Generic;

namespace ITMS.Services.Interface
{
    public interface ICommonLookupService
    {
        List<CommonLookUp> GetCommonLookUpList();
        CommonLookUp GetCommonlookUpById(Guid id);
        string CreateCommonLookUp(CommonLookUpViewModel model);
        string UpdateCommonLookUp(CommonLookUpViewModel model);
        void DeleteCommomLookUp(Guid id);
    }
}
