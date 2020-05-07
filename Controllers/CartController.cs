using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab234.HelperSession;
using lab234.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace lab234.Controllers
{
    
    public class CartController : Controller
    {
        private readonly ProductData productData;

        public CartController(ProductData productData)
        {
            this.productData = productData;
        }

        //private readonly ProductModel productModel;
        //public CartController(ProductModel productModel)
        //{
        //    this.productModel = productModel;
        //}

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.ProductModel.ProductPrice * item.Quantity);

            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") == null)
            {
                List<ProductToCart> cart = new List<ProductToCart>(); cart.Add(new ProductToCart
                { ProductModel = productData.ProductList.FirstOrDefault(p => p.ProductId == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart"); int index = isExist(id); if (index != -1) { cart[index].Quantity++; }

                else { cart.Add(new ProductToCart { ProductModel = productData.ProductList.FirstOrDefault(p => p.ProductId == id), Quantity = 1 }); }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session,
           "cart", cart);
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductModel.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }

}
