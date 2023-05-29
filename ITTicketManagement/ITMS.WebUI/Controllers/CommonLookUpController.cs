using ITMS.Model.Models;
using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ITMS.WebUI.Controllers
{
    public class CommonLookUpController : Controller
    {
        ICommonLookupService _commonLookUpservice;
        public CommonLookUpController(ICommonLookupService commonLookUpservice)
        {
            _commonLookUpservice = commonLookUpservice;
        }
        // GET: CommonLookUp

        public ActionResult Index()
        {
            List<CommonLookUp> commonLookUps = _commonLookUpservice.GetCommonLookUpList();
            return View(commonLookUps);
        }
        public ActionResult Create()
        {
            CommonLookUpViewModel commonLookUp = new CommonLookUpViewModel();
            return View(commonLookUp);
        }

        [HttpPost]
        public ActionResult Create(CommonLookUpViewModel model)
        {
            if (model.ConfigKey == null && model.ConfigName == null)
            {
                return Content("Null");
            }
            var clp = _commonLookUpservice.CreateCommonLookUp(model);
            if (clp != "Success")
            {
                return Content("Already Exists");

            }
            else
            {
                return Content("");
            }
        }
        public ActionResult Edit(Guid id)
        {
            CommonLookUp commonLookUp = _commonLookUpservice.GetCommonlookUpById(id);
            if (commonLookUp == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(commonLookUp);
            }
        }

        [HttpPost]
        public ActionResult Edit(CommonLookUpViewModel model)
        {

            if (model.ConfigKey == null && model.ConfigName == null)
            {
                return Content("Null");
            }
            var clp2 = _commonLookUpservice.UpdateCommonLookUp(model);
            if (clp2 != "success")
            {
                return Content("Already Exists");
            }
            else
            {
                return Content("");
            }
        }
        public ActionResult Delete(Guid id)
        {
            _commonLookUpservice.DeleteCommomLookUp(id);
            return RedirectToAction("Index", "CommonLookUp");
        }

    }
}