using ITMS.Data.Interface;
using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITMS.Services.Services
{

    public class RoleService : IRoleService
    {
        IRoleRepository roleRepository;
      
        public RoleService(IRoleRepository RoleRepository)
        {
            this.roleRepository = RoleRepository;
        }
        public List<Roles> GetRoleList()
        {
            return roleRepository.GetAll().Where(x => !x.IsDeleted).OrderByDescending(x => x.CreatedOn).ToList();
        }
        public string CreateRole(RoleViewmodel model)
        {
            if (roleRepository.GetAll().Where(x => x.Name == model.Name && !x.IsDeleted).Any())
            {
                return "Name already exist";
            }
            if (roleRepository.GetAll().Where(x => x.Code == model.Code && !x.IsDeleted).Any())
            {
                return "Code already exist";
            }
            Roles roleData = new Roles();
            roleData.Code = model.Code.ToUpper().Trim();
            roleData.Name = model.Name;
            roleRepository.Add(roleData);
            roleRepository.SaveChanges();
            return null;
        }
        public RoleViewmodel GetRole(Guid Id)
        {
            Roles role = roleRepository.GetById(Id)
;
            RoleViewmodel roleViewModel = new RoleViewmodel();
            roleViewModel.Id = role.Id;
            roleViewModel.Name = role.Name;
            roleViewModel.Code = role.Code;
            return roleViewModel;
        }
        public string UpdateRole(RoleViewmodel model)
        {
            Roles roleData = roleRepository.GetById(model.Id);
            roleData.Code = model.Code.ToUpper().Trim();
            roleData.Name = model.Name;
            roleRepository.Update(roleData);
            roleRepository.SaveChanges();
            return null;
        }
        public void RemoveRole(Guid Id)
        {
            Roles role = roleRepository.GetAll().Where(x => x.Id == Id).FirstOrDefault();
            role.IsDeleted = true;
            roleRepository.Update(role);
            roleRepository.SaveChanges();
        }
    }
}
