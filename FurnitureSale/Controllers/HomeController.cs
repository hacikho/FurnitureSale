using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureSale.DAL;

namespace FurnitureSale.Controllers
{
    public class HomeController : BaseController
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

        // GET: Living Room
        [HttpGet]
        public ActionResult LivingRoom()
        {
            //var products = dal.GetLast20Products();
            return View("LivingRoom");
        }

        // GET: BedRoom
        [HttpGet]
        public ActionResult BedRoom()
        {
            //var products = dal.GetLast20Products();
            return View("BedRoom");
        }

        // GET: DiningRoom
        [HttpGet]
        public ActionResult DiningRoom()
        {
            //var products = dal.GetLast20Products();
            return View("DiningRoom");
        }

        // GET: Kitchen
        [HttpGet]
        public ActionResult Kitchen()
        {
            //var products = dal.GetLast20Products();
            return View("Kitchen");
        }

        // GET: Kitchen
        [HttpGet]
        public ActionResult BabiesKids()
        {
            //var products = dal.GetLast20Products();
            return View("BabiesKids");
        }


    }
}