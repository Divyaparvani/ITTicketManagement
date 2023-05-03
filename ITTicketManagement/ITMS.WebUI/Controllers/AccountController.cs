using ITMS.Model.ViewModels;
using ITMS.Services.Interface;
using System.Web.Mvc;
using System.Web.Security;

namespace ITMS.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            this._loginService = loginService;
        }
        public ActionResult Login()
        {
            AccountViewModel model = new AccountViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user = _loginService.Login(model);

                if (user != null)
                {
                    Session["Email"] = model.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password wrong");
                    return View(model);
                }
            }
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}