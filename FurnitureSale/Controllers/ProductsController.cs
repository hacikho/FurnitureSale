using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureSale.Models;
using FurnitureSale.DAL;
using System.IO;
using System.Web.Helpers;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace FurnitureSale.Controllers
{

    public class ProductsController : BaseController
    {
        CloudinaryDotNet.Account account =
    new CloudinaryDotNet.Account("hsaf29tj8", "434155939431716", "d-xsjMrt4vHfGPceFQRZEGh3sTY");
        

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
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            if (productImage != null)
            {  
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.FileDescription(productImage.FileName, productImage.InputStream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                p.ImageName1 = url;
            }

            //second image
            if (productImage2 != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.FileDescription(productImage2.FileName, productImage2.InputStream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                p.ImageName2 = url;
            }

            //third image
            if (productImage3 != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.FileDescription(productImage3.FileName, productImage3.InputStream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                p.ImageName3 = url;
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
        public ActionResult EditProduct(Product productToEdit, HttpPostedFileBase productImage, HttpPostedFileBase productImage2, HttpPostedFileBase productImage3)
        {
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            //dal.EditProduct(productToEdit.Id, productToEdit);
            if (productImage != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.FileDescription(productImage.FileName, productImage.InputStream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                productToEdit.ImageName1 = url;
            }

            //second image
            if (productImage2 != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.FileDescription(productImage2.FileName, productImage2.InputStream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                productToEdit.ImageName2 = url;
            }

            //third image
            if (productImage3 != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new CloudinaryDotNet.FileDescription(productImage3.FileName, productImage3.InputStream),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                productToEdit.ImageName3 = url;
            }
            dal.EditProduct(productToEdit);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeleteProduct(int id = 0)
        {
            Product p = dal.GetProduct(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View("DeleteProduct", p);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int id) 
        {
            dal.DeleteConfirm(id);
            return RedirectToAction("Inventory", "Products");
        }
        
    } 
}