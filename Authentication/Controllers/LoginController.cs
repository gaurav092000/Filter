using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Authentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        UserdataContext db=new UserdataContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(UserData u,string ReturnUrl)
        {
            if (Isvalid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["Username"] = u.UserName.ToString();
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

        public bool Isvalid (UserData u)
        {
            var data = db.userDatas.Where(model => model.UserName == u.UserName && model.Password == u.Password).FirstOrDefault();
            if(data != null )
            {
            return (data.UserName == u.UserName && data.Password == u.Password);

            }
            else
            {
                return false;
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Username"] = null;
            return RedirectToAction("Index","Home");
           
        }
    }
}