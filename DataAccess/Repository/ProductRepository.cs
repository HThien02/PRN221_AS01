using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts() => ProductDAO.Instance.GetAllProducts();

        public IEnumerable<Product> GetProductsByPrice(decimal price) => ProductDAO.Instance.GetProductsByPrice(price);

        public IEnumerable<Product> GetProductsByQuantity(int unit) => ProductDAO.Instance.GetProductsByUnits(unit);

        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);
       
        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.Instance.DeleteProduct(product);

        public Product GetProductById(int id) => ProductDAO.Instance.getProductById(id);

    }
}
