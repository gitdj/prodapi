using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
//using WebApi.DataLayer;

namespace WebApi.ServiceLayer.Svc
{
    public class ProductService : IProductService
    {
        #region EFCode  
        //private BTDJEntities dbEFObj = new BTDJEntities();

        //public List<Product> Get()
        //{
        //    return dbEFObj.Products.ToList();
        //}

        //public Product GetById(int Id)
        //{
        //    return dbEFObj.Products.Where(x => x.ProductID == Id).FirstOrDefault();
        //}

        //public List<Product> UpdateProduct(Product prodReq)
        //{
        //    dbEFObj.Entry(prodReq).State = System.Data.Entity.EntityState.Modified;
        //    dbEFObj.SaveChanges();
        //    return dbEFObj.Products.ToList();
        //}

        //public Product AddProduct(Product prodReq)
        //{
        //    dbEFObj.Products.Add(prodReq);
        //    dbEFObj.SaveChanges();
        //    return dbEFObj.Products.Where(x => x.ProductID == prodReq.ProductID).FirstOrDefault();
        //}

        //public bool DeleteProduct(Product prodReq)
        //{
        //    dbEFObj.Entry(prodReq).State = System.Data.Entity.EntityState.Deleted;
        //    dbEFObj.SaveChanges();
        //    return true;
        //}
        #endregion EFCode  


        private static List<Product> products = new List<Product>()
        { new Product { ProductID =1, ProductName="MacApple", Price=100, Quantity=2},
                 new Product { ProductID =2, ProductName="Samsung", Price=90, Quantity=2},
                  new Product { ProductID =3, ProductName="Moto", Price=70, Quantity=2},
                   new Product { ProductID =4, ProductName="Nokia", Price=60, Quantity=2},
                   new Product { ProductID =5, ProductName="Deployment", Price=60, Quantity=2},
                   new Product { ProductID =6, ProductName="DeploymentSCM", Price=60, Quantity=2},
                   new Product { ProductID =7, ProductName="DeploymentDeploymentSlot", Price=60, Quantity=2}

            };
        public List<Product> Get()
        {
            products = Loadproducts();
            return products.ToList();            
        }

        public Product GetById(int Id)
        {
            products = Loadproducts();
            return products.Where(x => x.ProductID == Id).FirstOrDefault();
        }

        public List<Product> UpdateProduct(Product prodReq)
        {
            products = Loadproducts();
            int index= products.FindIndex(x => x.ProductID == prodReq.ProductID);
            products.RemoveAt(index);
            products.Add(prodReq);
            SaveProducts(products);
            return products.ToList();
        }

        public Product AddProduct(Product prodReq)
        {
            products = Loadproducts();
            products.Add(prodReq);
            SaveProducts(products);
            return products.Where(x => x.ProductID == prodReq.ProductID).FirstOrDefault();
        }

        public bool DeleteProduct(Product prodReq)
        {
            products = Loadproducts();
            int index = products.FindIndex(x => x.ProductID == prodReq.ProductID);
            if (index>=0)
            {
                products.RemoveAt(index);
                SaveProducts(products);
                return true;
            }
            return false;           
            
        }

        private List<Product> Loadproducts()
        {
            //    string path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["FilePath"]);

            //List<Product> listofa = new List<Product>();
            //Product pro = new Product();
            //XmlSerializer formatter = new XmlSerializer(products.GetType());
            //if (System.IO.File.Exists(path))
            //{
            //    FileStream aFile = new FileStream(path, FileMode.Open);
            //    byte[] buffer = new byte[aFile.Length];
            //    aFile.Read(buffer, 0, (int)aFile.Length);
            //    MemoryStream stream = new MemoryStream(buffer);
            //    aFile.Dispose();
            //    aFile.Close();
            //    return (List<Product>)formatter.Deserialize(stream);
            //}
            //else
            //{
            //    return products;
            //}

           
            return products;
        }


        private void SaveProducts(List<Product> listofProduct)
        {
            try
            {
                //string path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["FilePath"]);
                
                //FileStream outFile = File.Open(path, FileMode.Create);
                //XmlSerializer formatter = new XmlSerializer(listofProduct.GetType());
                //formatter.Serialize(outFile, listofProduct);
                //outFile.Dispose();
                //outFile.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }

    public interface IProductService
    {
        List<Product> Get();
        Product GetById(int Id);

        Product AddProduct(Product prodReq);
        List<Product> UpdateProduct(Product prodReq);
        bool DeleteProduct(Product prodReq);
    }
}