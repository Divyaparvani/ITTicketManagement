using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace ITMS.WebUI.Controllers
{
    public class RoleController : Controller
    {
        IRoleService RoleService;
        public RoleController(IRoleService roleService)
        {
            RoleService= roleService;
        }
        // GET: Role
        public ActionResult Index()
        {
            List<Roles> roles = RoleService.GetRoleList().ToList();
            return View(roles);
        }

        public ActionResult Create()
        {   
            return View(new RoleViewmodel());
        }

        [HttpPost]
        public ActionResult Create(RoleViewmodel model)
        {
            var roles = RoleService.CreateRole(model);
            if (roles!=null)
            {
                ViewBag.Message = roles;
                return View(model);
            }
            else
            {
              return RedirectToAction("Index", "Role");
            }
        }

        public ActionResult Edit(Guid Id)
        {
            RoleViewmodel role = RoleService.GetRole(Id);
            if (role == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(role);
            }
        }

        [HttpPost]
        public ActionResult Edit(RoleViewmodel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var roles = RoleService.UpdateRole(model);
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(Guid Id)
        {
            RoleService.RemoveRole(Id);
            return RedirectToAction("Index","Role");
        }
    }
}