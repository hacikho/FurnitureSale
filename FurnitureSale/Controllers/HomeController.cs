using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureSale.DAL;

namespace FurnitureSale.Controllers
{
    public class HomeController : Controller
    {
        private IProductDAL dal;
        public HomeController(IProductDAL dal)
        {
            this.dal = dal;
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var products = dal.GetLast20Products();
            return View("Index", products);
        }
    }
}