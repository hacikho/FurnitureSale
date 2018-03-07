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
            var products = dal.GetLivingRoomProducts();
            return View("LivingRoom", products);
        }

        // GET: BedRoom
        [HttpGet]
        public ActionResult BedRoom()
        {
            var products = dal.GetBedRoomProducts();
            return View("BedRoom", products);
        }

        // GET: DiningRoom
        [HttpGet]
        public ActionResult DiningRoom()
        {
            var products = dal.GetDiningRoomProducts();
            return View("DiningRoom",products);
        }

        // GET: BabiesKids
        [HttpGet]
        public ActionResult BabiesKids()
        {
            var products = dal.GetBabiesKidsProducts();
            return View("BabiesKids", products);
        }

        // get: kitchen
        [HttpGet]
        public ActionResult Kitchen()
        {
            var products = dal.GetKitchenProducts();
            return View("Kitchen", products);
        }


    }
}