using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingMvc.Models;
using System.Net.Http;
using Newtonsoft.Json;//for json content
namespace OnlineShoppingMvc.Controllers
{
    /// <summary>
    /// This Controller is used for Client side
    /// </summary>
    public class OnlineShoppingController : Controller
    {
        // GET: OnlineShopping        
        public ActionResult Index()
        {
            
            //Attaching the address of API
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("OnlineShopping/GetAllCategories/").Result;
                //To convert to JSON Format
                var lstRec = JsonConvert.DeserializeObject<List<Home>>(result);
                return View(lstRec);
            }
        }
        
        [HttpGet]
        //get
        public ActionResult SearchByProduct(string name)
        {
            //Attaching the address of API
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                //Attaching the address of API
                client.BaseAddress = uri;
                var result = client.GetStringAsync("OnlineShopping/GetProductsByProductName/" + name).Result;
                //To Convert to JSON
                var p = JsonConvert.DeserializeObject<List<Products>>(result);
                //return view
                return View(p);
            }
        }
        //Get
        [HttpGet]
        public ActionResult GetByCategory(string name)
        {
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                //Attaching the connection of API
                client.BaseAddress = uri;
                var result = client.GetStringAsync("OnlineShopping/GetProductsByCategoryName/" + name).Result;
                //To Convert to Json Format
                var c = JsonConvert.DeserializeObject<List<Products>>(result);
               // return view
                return View(c);
            }
        }
        public ActionResult GetByProductId(int id)
        {
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                //Attaching the connection of API
                client.BaseAddress = uri;
                var result = client.GetStringAsync("OnlineShopping/GetProductDetails/" + id).Result;
                //To Convert to Json Format
                var c = JsonConvert.DeserializeObject<ProductDetails>(result);
                //return view
                return View(c);
            }
        }
        //Get
        [HttpGet]
        public ActionResult AddToCart()
        {
            //return View
            return View();
        }
        public ActionResult BuyNow()
        {
            //return View
            return View();
        }
        //post
        [HttpPost]
        public ActionResult AddToCart(Cart item)
        {

            if (Session["cart"] == null)
            {
                var cartlst = new List<Cart>();
                cartlst.Add(item);
                Session.Add("Count", cartlst);

            }
            else
            {
                var cartlst = new List<Cart>();
                cartlst.Add(item);
                Session["cart"] = cartlst;
            }
            //Redirecting to Cart
            return RedirectToAction("Displaycart");
        }
        public ActionResult DisplayCart()
        {
            var cartlst = new List<Cart>();
            //return view
            return View("cartlst");
        }
        //Get
        [HttpGet]
        public ActionResult Create()
        {
         
            //return view
              return View();

        }
        //post
        [HttpPost]
        //This Action is used for creating a new product
        public ActionResult Create(Products pr)
        { 
                //configure the address of API
                Uri uri = new Uri("http://localhost:56805/api/");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = uri;
                    var result = client.PostAsJsonAsync("OnlineShopping/", pr).Result;
                    //Checking the status code
                    if (result.IsSuccessStatusCode == true)
                    {
                        ViewData.Add("msg", "Record inserted");
                    }
                    else { ViewData.Add("msg", "Record not insertred"); }
                }
                return View();

        }
        //This action method is used to give the details
        public ActionResult Details(int id)
        {
            //Configuring the connection from API
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("OnlineShopping/" + id).Result;
                //To Convert to JSON Format
                var pr = JsonConvert.DeserializeObject<Products>(result);

                return View(pr);
            }

        }
        //get
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        //post
        [HttpPost]
        //This action method is used to delete a product using id
        public ActionResult Delete(int id)
        {
            //Configuring the connection from API
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("OnlineShopping/DeleteProductById/" +id).Result;
                //Checking the statuscode
                if (result.IsSuccessStatusCode == true)
                {
                    ViewData.Add("msg", "record deleted");

                }
                else
                {
                    TempData.Add("msg", "Delete Error");
                }
            }
            return RedirectToAction("Index");
        }
        //Get
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        //Post
        [HttpPost]
        //This action method is used to update a record 
        public ActionResult Edit(Products pr)
        {
            Uri uri = new Uri("http://localhost:56805/api/");
            using (var client = new HttpClient())
            {
                //Configuring the connection from API
                client.BaseAddress = uri;
                var result = client.PutAsJsonAsync("OnlineShopping/",pr).Result;
                //Checking the status code
                if (result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("msg", "update Error");
                }
                return View();

            }

        }
    }
}