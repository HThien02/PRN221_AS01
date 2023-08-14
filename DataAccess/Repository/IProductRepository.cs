using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        // perform the same functions in IMemberRepository
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByPrice(decimal price);
        IEnumerable<Product> GetProductsByQuantity(int unit);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductById(int id);
        
    }
}
