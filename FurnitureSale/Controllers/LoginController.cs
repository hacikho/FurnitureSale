using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureSale.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult AdminLogin()
        {
            return View("AdminLogin");
        }

        [HttpPost]
        public ActionResult AdminLogin(FormCollection frmc)
        {
            /// Extracting the value from FormCollection
            string name = frmc["userName"];
            string pwd = frmc["Password"];
            if(name=="Admin" && pwd ==  "password")
            {
                this.SharedSession["UserName"] = "Admin";
                //Changes
                return RedirectToAction("NewProduct", "Products");
            }
            else
            {
                return View("AdminLogin");
            }

        }

        public ActionResult logout()
        {
            Session.Abandon();
            return View("Logout");
            
        }

    }
}

