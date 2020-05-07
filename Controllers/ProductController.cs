using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using lab234.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace lab234.Controllers
{
    public class ProductController : Controller
    {
        ProductData productData;
        public ProductController(ProductData productData)
        {
            this.productData = productData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductModel> products = productData.ProductList; return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ProductModel productModel = new ProductModel();
            return View(productModel);
        }
        [HttpPost]
        public IActionResult Add(ProductModel productModel, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                ProductModel newProduct = new ProductModel(); if (photo == null || photo.Length == 0)
                {
                    newProduct.ProductImage = "abc.png";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream); newProduct.ProductImage = photo.FileName;
                }
                newProduct.ProductName = productModel.ProductName;
                newProduct.ProductQuantity = productModel.ProductQuantity;
                newProduct.ProductPrice = productModel.ProductPrice;
                newProduct.CreateDate = DateTime.Now; productData.ProductList.Add(newProduct);
                return RedirectToAction("Index", "Product");
            }
            else { return View(productModel); }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductModel oldProduct = productData.ProductList.FirstOrDefault(p => p.ProductId == id);
            return View(oldProduct);
        }
        [HttpPost]
        public IActionResult Edit(int id, ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                ProductModel oldProduct = productData.ProductList.FirstOrDefault(p => p.ProductId == id);
                oldProduct.ProductName = productModel.ProductName;

                oldProduct.ProductQuantity = productModel.ProductQuantity;
                oldProduct.ProductPrice = productModel.ProductPrice;
                oldProduct.CreateDate = DateTime.Now; ViewBag.Status = 1;
            }
            return View(productModel);
        }

        public IActionResult Delete(int id)
        {
            ProductModel oldProduct = productData.ProductList.FirstOrDefault(p => p.ProductId == id);
            return View(oldProduct);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            productData.ProductList.RemoveAll(p => p.ProductId == id);
            return RedirectToAction("Index", "Product");
        }
    }
}