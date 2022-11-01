using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.ServiceLayer.Svc
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}