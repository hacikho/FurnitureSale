﻿using System;
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

        //[HttpGet]
        //public ActionResult Inventory()
        //{
        //    if(SharedSession["UserName"] == "Admin")
        //    {
        //        return View("Inventory");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        // GET: Inventory
        [HttpGet]
        public ActionResult Inventory()
        {
            //var products = dal.GetLast20Products();
            //return View("Inventory", products);

            if (SharedSession["UserName"] == "Admin")
            {
                var products = dal.GetAllProducts();
                return View("Inventory", products);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult NewProduct(Product p, HttpPostedFileBase productImage, HttpPostedFileBase productImage2, HttpPostedFileBase productImage3)
        {
            if(productImage != null)
            {
                string extension = Path.GetExtension(productImage.FileName);
                string filename = Guid.NewGuid() + extension;
                
                string placeToSaveIt = Path.Combine(Server.MapPath("~/images/"), filename);

                productImage.SaveAs(placeToSaveIt);
                p.ImageName1 = filename;
            }

            //second image
            if (productImage2 != null)
            {
                string extension = Path.GetExtension(productImage2.FileName);
                string filename = Guid.NewGuid() + extension;

                string placeToSaveIt = Path.Combine(Server.MapPath("~/images/"), filename);

                productImage2.SaveAs(placeToSaveIt);
                p.ImageName2 = filename;
            }

            //third image
            if (productImage3 != null)
            {
                string extension = Path.GetExtension(productImage3.FileName);
                string filename = Guid.NewGuid() + extension;

                string placeToSaveIt = Path.Combine(Server.MapPath("~/images/"), filename);

                productImage3.SaveAs(placeToSaveIt);
                p.ImageName3 = filename;
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
        public ActionResult EditProduct(Product productToEdit, HttpPostedFileBase productImage)
        {
            //dal.EditProduct(productToEdit.Id, productToEdit);
            if (productImage != null)
            {
                string extension = Path.GetExtension(productImage.FileName);
                string filename = Guid.NewGuid() + extension;

                string placeToSaveIt = Path.Combine(Server.MapPath("~/images/"), filename);

                productImage.SaveAs(placeToSaveIt);
                productToEdit.ImageName1 = filename;
            }
            dal.EditProduct(productToEdit);
            return RedirectToAction("Index", "Home");
        }

        
    } 
}