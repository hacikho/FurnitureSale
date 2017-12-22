using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureSale.Models;
using FurnitureSale.DAL;
using System.IO;
using System.Web.Helpers;

namespace FurnitureSale.Controllers
{
    public class ProductsController : BaseController
    {
        Product newProduct = new Product();
        private IProductDAL dal;
        public ProductsController(IProductDAL dal)
        {
            this.dal = dal;
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            if(SharedSession["UserName"] == "Admin")
            {
                return View("NewProduct");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult NewProduct(Product p, HttpPostedFileBase productImage)
        {
            if(productImage != null)
            {
                string extension = Path.GetExtension(productImage.FileName);
                string filename = Guid.NewGuid() + extension;
                
                string placeToSaveIt = Path.Combine(Server.MapPath("~/images/"), filename);

                productImage.SaveAs(placeToSaveIt);
                p.ImageName1 = filename;
            }

            dal.SaveNewProduct(p);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detail(int id = 0)
        {
            Product p = dal.GetProduct(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View("Detail", p);
        }

        [HttpGet]
        public ActionResult EditProduct(int id = 1)
        {
            newProduct = dal.GetProduct(id);
            return View("EditProduct", newProduct);
        }

        [HttpPost]
        public ActionResult EditProduct(Product productToEdit)
        {
            dal.EditProduct(productToEdit.Id, productToEdit);
            return RedirectToAction("Index", "Home");
        }
    } 
}