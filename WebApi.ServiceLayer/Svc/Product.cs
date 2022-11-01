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

        public class UserInputProduct
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Qty { get; set; }
            public double Cost { get; set; }
        }
    }