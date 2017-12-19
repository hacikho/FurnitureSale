using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureSale.Models;
using FurnitureSale.DAL;


namespace FurnitureSale.Controllers
{
    public class ProductsController : Controller
    {
        private IProductDAL dal;
        public ProductsController(IProductDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            return View("NewProduct");
        }

        [HttpPost]
        public ActionResult NewProdcut(Product p)
        {
            dal.SaveNewProduct(p);
            return RedirectToAction("Index", "Home");
        }
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }


    }
}