using BusinessObject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> productList;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    productList = sale.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public Product getProductById(int id)
        {
            Product product = null;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    product = sale.Products.SingleOrDefault(p => p.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByPrice(decimal price)
        {
            List<Product> productList;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    productList = sale.Products.Where(p => p.UnitPrice == price).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public IEnumerable<Product> GetProductsByUnits(int unit)
        {
            List<Product> productList;
            try
            {
                using (var sale = new PRN221_AS1Context())
                {
                    productList = sale.Products.Where(p => p.UnitslnStock == unit).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }
        
        public void AddProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p == null)
                {
                    using (var sale = new PRN221_AS1Context())
                    {
                        sale.Products.Add(product);
                        sale.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("The product already exists");
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var sale = new PRN221_AS1Context())
                    {
                        sale.Entry(product).State = EntityState.Modified;
                        sale.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var sale = new PRN221_AS1Context())
                    {
                        sale.Products.Remove(product);
                        sale.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("The product doesn't exist");
            }
        }

    }
}
