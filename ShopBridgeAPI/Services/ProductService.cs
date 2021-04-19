
using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var p = _dbContext.Add(product);
            _dbContext.SaveChanges();
            return product;
            //throw new System.NotImplementedException();
        }

        public async Task<bool>  DeleteProduct(Product product)
        {
             var r= _dbContext.Product.Remove(product);
            _dbContext.SaveChanges();

            return true;
            //throw new System.NotImplementedException();
        }

        public async Task<Product> GetProduct(int Id)
        {
            return _dbContext.Product.Find(Id);
        }

        public async Task<List<Product>> GetProducts()
        {
            //throw new System.NotImplementedException();
            return _dbContext.Product.ToList();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var isProductExist = _dbContext.Product.AsNoTracking().First(a=>a.Id == product.Id);
            if(isProductExist != null)
            {
                 _dbContext.Product.Update(product);
                _dbContext.SaveChanges();
            }
            return product;
            //throw new System.NotImplementedException();
        }
    }
}
