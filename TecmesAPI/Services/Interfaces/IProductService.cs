using TecmesAPI.Models;

namespace TecmesAPI.Services.Interfaces
{
    public interface IProductService
	{
        Task<IEnumerable<Product>> getAllProducts();
        Task<IEnumerable<Product>> getProductsByName(string name);
        Task<Product> getProductById(int id);
        Task<Product> addProduct(Product product);
        Task<Product> updateProduct(Product product, int id);
        Task<bool> deleteProduct(int id);
    }
}

