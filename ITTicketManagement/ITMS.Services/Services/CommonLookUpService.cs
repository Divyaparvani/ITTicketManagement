using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITMS.Services.Services
{
    public class CommonLookUpService : ICommonLookupService
    {
        ICommonLookUpRepository _commonLookUpRepository;
        public CommonLookUpService(ICommonLookUpRepository CommonLookUpRepository)
        {
            _commonLookUpRepository = CommonLookUpRepository;
        }

        public List<CommonLookUp> GetCommonLookUpList()
        {
            return _commonLookUpRepository.GetCommonLookUpList().ToList();
        }

        public string CreateCommonLookUp(CommonLookUpViewModel model)
        {
            if (_commonLookUpRepository.CheckIfExist(model.ConfigName, model.ConfigKey))
            {
                return "Already exist";
            }

            CommonLookUp commonLook = new CommonLookUp
            {
                ConfigKey = model.ConfigKey,
                ConfigName = model.ConfigName,
                ConfigValue = model.ConfigValue,
                DisplayOrder = model.DisplayOrder,
                Description = model.Description,
                IsActive = model.IsActive
            };
            _commonLookUpRepository.CreateCommonlookUp(commonLook);
            return "success";
           
        }
        public CommonLookUp GetCommonlookUpById(Guid id)
        {
            return _commonLookUpRepository.GetCommonlookUpById(id);
        }

        public string UpdateCommonLookUp(CommonLookUpViewModel model)
        {

            if (_commonLookUpRepository.CheckIfExist(model.ConfigName, model.ConfigKey, true,model.Id))
            {
                return "Already exist";
            }
            //if (_commonLookUpRepository.GetCommonLookUpList().Where(x => x.ConfigName == model.ConfigName && !x.IsDeleted && x.Id != model.Id).Any())
            //{
            //    return "configName already exist";
            //}
            //if (_commonLookUpRepository.GetCommonLookUpList().Where(x => x.ConfigKey == model.ConfigKey && !x.IsDeleted && x.Id != model.Id).Any())
            //{
            //    return "configkey already exist";
            //}

            CommonLookUp commonLookUpforupdate = _commonLookUpRepository.GetCommonlookUpById(model.Id);
            if(commonLookUpforupdate != null)
            {
                commonLookUpforupdate.ConfigKey = model.ConfigKey;
                commonLookUpforupdate.ConfigName = model.ConfigName;
                commonLookUpforupdate.ConfigValue = model.ConfigValue;
                commonLookUpforupdate.DisplayOrder = model.DisplayOrder;
                commonLookUpforupdate.Description = model.Description;

                _commonLookUpRepository.UpdateCommonLookUp(commonLookUpforupdate);
                return "Success";
            }
            return "Not Exist CommonLookUp";
        }

        public void DeleteCommomLookUp(Guid id)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.GetCommonlookUpById(id);
            if(commonLookUp == null)
            {
                return;
            }
            commonLookUp.IsDeleted = true;
            _commonLookUpRepository.SaveChanges();
          
        }
    }
}
