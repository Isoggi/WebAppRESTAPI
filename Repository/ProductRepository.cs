using WebAppRESTAPI.Models;
using WebAppRESTAPI.Repository.Interface;

namespace WebAppRESTAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<List<Product>> GetList(string keyword = null)
        {
            List<Product> result = new List<Product>();
            return result;
        }

        public async Task<Product> GetDetail(string id)
        {
            Product result = new Product();
            return result;
        }
        public async Task<Product> Create(Product product)
        {
            Product result = new Product();
            return result;
        }
        public async Task<Product> Update(Product product)
        {
            Product result = new Product();
            return result;
        }
        public async Task<bool> Delete(string id)
        {
            bool result = false;
            return result;
        }
    }
}
