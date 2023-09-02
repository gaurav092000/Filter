using AuthorizeFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthorizeFilter.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        LoginContext db=new LoginContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(LoginUser u,string ReturnUrl)
        {
           if(Isvalid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["User"] = u.UserName.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");   
                }
            }
           else
            {
                return View();
            }
           

        }

        public bool Isvalid(LoginUser u)
        {

            var creditial = db.logins.Where(model => model.UserName == u.UserName && model.Password == u.Password).FirstOrDefault();
            return (u.UserName == creditial.UserName && u.Password == creditial.Password);
        }
    }
}