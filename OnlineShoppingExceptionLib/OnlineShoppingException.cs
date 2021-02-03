using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingExceptionLib
{
    /// <summary>
    /// This Class is used for Custom Exception by user
    /// </summary>
    public class OnlineShoppingException : Exception
    {
        //Inheriting the basic Exception class
        public OnlineShoppingException(string errMsg) : base(errMsg)
        {
            //TO Do
        }
    }
}
