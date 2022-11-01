using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApi.ServiceLayer;
using WebApi.ServiceLayer.Svc;

namespace Products.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        //private List<Product> products = new List<Product>()
        //{ new Product { ProductID =1, ProductName="Apple", Price=100, Quantity=2},
        //     new Product { ProductID =2, ProductName="Samsung", Price=90, Quantity=2},
        //      new Product { ProductID =3, ProductName="Moto", Price=70, Quantity=2},
        //       new Product { ProductID =4, ProductName="Nokia", Price=60, Quantity=2}
        //};

        private IProductService svcLayer = new ProductService();

        public IEnumerable<Product> Get()
        {
            return svcLayer.Get();
        }

        public IHttpActionResult Get(int Id)
        {
            var prod = svcLayer.GetById(Id);
            if (prod == null)
            {
                NotFound();
            }            
            return Ok(prod);
        }

        public IHttpActionResult Post(Product prodReq)
        {
            Product prod = svcLayer.AddProduct(prodReq);            
            if (prod == null)
            {
                NotFound();
            }
            return Ok(prod);
        }


        public IEnumerable<Product> Put(Product prodReq)
        {
            List<Product> prod = svcLayer.UpdateProduct(prodReq);
            return prod.ToList();
        }

        public IHttpActionResult Delete(Product prodReq)
        {
            bool flag = svcLayer.DeleteProduct(prodReq);
            if (flag)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
