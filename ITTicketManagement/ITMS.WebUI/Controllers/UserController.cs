using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ITMS.WebUI.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Role
        public ActionResult Index()
        {
            List<UserViewModel> users = _userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            UserViewModel user = new UserViewModel
            {
                RoleDropDown = _userService.GetRolesForDropDown()
            };
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {

           var user= _userService.CreateUser(model);
            //if (!ModelState.IsValid)
            if (user!= "success")
           {
                ViewBag.message = "user alredy exist";
                model.RoleDropDown = _userService.GetRolesForDropDown();
                return View(model);
            }
            else
            {
                //_userService.CreateUser(model);
                return RedirectToAction("Index", "User");
            }
        }

        public ActionResult Edit(Guid id)
        {
            UserViewModel user = _userService.GetUserForEdit(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                _userService.UpdateUser(model);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Guid id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index", "User");
        }

    }
}