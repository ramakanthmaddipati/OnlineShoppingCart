using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineShoppingEntityLib;//Using Entity Library
using OnlineShoppingBusinessLayerLib;

namespace OnlineShoppingAPI.Controllers
{
    /// <summary>
    /// This Controller is used for API side
    /// </summary>
    public class OnlineShoppingController : ApiController
    {
        
        //Routing
        [Route("api/OnlineShopping/GetAllCategories")]
        public List<Home> Get()
        {
                //Accessing data using with the businneslayer
                OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
                var clst = bll.GetAllCategories();
                return clst;
                        
        }
        //Routing
        [Route("api/OnlineShopping/GetProductsByProductName/{name}")]
        public List<Products> GetByName(string name)
        {
            //Accessing data
            OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
            var clst = bll.GetProductsByProductName(name);
            return clst;
        }
        //Routing
        [Route("api/OnlineShopping/GetProductsByCategoryName/{name}")]
        public List<Products> Get(string name)
        {
            OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
            var clst = bll.GetProductsByCategoryName(name);
            return clst;
        }
        //Routing
        [Route("api/OnlineShopping/GetProductDetails/{id}")]
        public ProductDetails Get(int id)
        {
            OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
            var d = bll.GetDetailsOfProduct(id);
            return d;
        }
        //Routing
        [Route("api/OnlineShopping/AddTocart/{id}")]
        public Cart GetCart(int id)
        {
            OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
            var d = bll.AddToCart(id);
            return d;
        }
        //Posting the data
        public HttpResponseMessage Post([FromBody] Products pr)
        {
              HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record added");
                //Handling the Exception
                try
                {
                    OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
                    bll.AddProduct(pr);
                }
                catch (Exception ex)
                {
                    errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not insert");
                }

                return errRes;
        }
        //Routing
        [Route("api/OnlineShopping/DeleteproductById{PId}")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Found");
            //Handling Exception
            try
            {
               OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
                bll.DeleteProductById(id);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id not found");
            }
            return errRes;

        }
        //Updating the Product
        public HttpResponseMessage put([FromBody] Products pr)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Updated");
            //Handling Exception
            try
            {
                OlShoppingBusinessLayer bll = new OlShoppingBusinessLayer();
                bll.UpdateProductById(pr);
            }
            catch
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Updation Error!!!");
            }
            return errRes;
        }

    }
}
