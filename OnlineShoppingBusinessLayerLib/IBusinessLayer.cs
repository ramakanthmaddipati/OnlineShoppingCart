using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingEntityLib;

namespace OnlineShoppingBusinessLayerLib 
{
    public interface IBusinessLayer
    { /// <summary>
      /// This method Is used for adding the product 
      /// </summary>
      /// <param name="pr"></param>
        void AddProduct(Products pr);
        /// <summary>
        /// This method is used for deleting a product by the parameter Productid(Pid)
        /// </summary>
        /// <param name="Pid"></param>
        void DeleteProductById(int Pid);
        /// <summary>
        /// This method is used to update a product by Id using the products class as  a parameter
        /// </summary>
        /// <param name="pr"></param>
        void UpdateProductById(Products pr);
        /// <summary>
        /// This method is used to get all the categories of the product
        /// </summary>
        /// <returns>list of categories</returns>
        List<Home> GetAllCategories();
        /// <summary>
        /// This method is used to get the products by the categoryname 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Products> GetProductsByCategoryName(string name);
        /// <summary>
        /// This method is used to get the products by the product name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>list of products</returns>
        List<Products> GetProductsByProductName(string name);
        /// <summary>
        /// This method is used to get all the details of the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list out the product details</returns>
        ProductDetails GetDetailsOfProduct(int id);
        /// <summary>
        /// This method is used to add a item to cart
        /// </summary>
        /// <param name="PId"></param>
        /// <returns>the cart items</returns>
        Cart AddToCart(int PId);
    }

}
