using System;
using Microsoft.EntityFrameworkCore;
using TecmesAPI.Context;
using TecmesAPI.Models;
using TecmesAPI.Services.Interfaces;

namespace TecmesAPI.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDBContext _dbContext;

        public ProductService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task<IEnumerable<Product>> getAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> getProductById(int id)
        {
            Product? product = await _dbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> getProductsByName(string name)
        {
            IEnumerable<Product> products;

            if (!string.IsNullOrWhiteSpace(name))
            {
                products = await _dbContext.Products.Where(n => n.Name.Contains(name)).ToListAsync();
            }
            else
            {
                products = await getAllProducts();
            }

            return products;
        }

        public async Task<Product> addProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }
        
        public async Task<Product> updateProduct(Product product, int id)
        {
            Product productById =  await getProductById(id);

            if(productById == null)
            {
                throw new Exception($"Produto para o ID: {id} não encontrado!");
            }

            productById.Name = product.Name;
            productById.Category = product.Category;
            _dbContext.Products.Update(productById);
            _dbContext.SaveChanges();

            return productById;
        }

        public async Task<bool> deleteProduct(int id)
        {
            Product productById = await getProductById(id);

            if (productById == null)
            {
                throw new Exception($"Produto para o ID: {id} não encontrado!");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

