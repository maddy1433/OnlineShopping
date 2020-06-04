using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class ProductController : Controller
    {
        IEnumerable<Product> products = null;
        // GET: Product
        public ActionResult Index()
        {
           
            ViewBag.Products = APICall();
            return View();
        }
        
        public ActionResult Category(string catName)
        {
            products = APICall();
            if (catName != "")
            {
                int _categoryId = 0;
                if (catName.Equals("Fashion"))
                    _categoryId = 1;
                else if (catName.Equals("Groceries"))
                    _categoryId = 2;
                else
                    _categoryId = 3;
                    products = products.Where(p => p.CategoryId == _categoryId).ToList<Product>();
            }
            ViewBag.Products = products;
            return View("Index");
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<Product> APICall()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52643/api/product/getallproducts/");

                //product / getAllProducts
                var responseTask = client.GetAsync("product");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Product>>();
                    readTask.Wait();

                    products = readTask.Result;
                }
                else
                {
                    //Error response received   
                    products = Enumerable.Empty<Product>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
                return products;
            }
        }
    }
}
