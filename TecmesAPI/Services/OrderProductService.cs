using Microsoft.EntityFrameworkCore;
using TecmesAPI.Context;
using TecmesAPI.Enums;
using TecmesAPI.Models;
using TecmesAPI.Services.Interfaces;

namespace TecmesAPI.Services
{
    public class OrderProductService : IOrderProductService
    {

        private readonly AppDBContext _dbContext;
        private readonly StatusOrder status;

        public OrderProductService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task<IEnumerable<OrderProduct>> getAll()
        {
            return await _dbContext.OrderProducts
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<OrderProduct> getById(int id)
        {
            var order = await _dbContext.OrderProducts
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task<OrderProduct> add(OrderProduct order)
        {
            await _dbContext.OrderProducts.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }
        
        public async Task<OrderProduct> update(OrderProduct order, int id)
        {
            OrderProduct orderById = await getById(id);

            if(orderById == null)
            {
                throw new Exception($"Produto para o ID: {id} não encontrado!");
            }

            orderById.Quantity = order.Quantity;
            orderById.ProductId = order.ProductId;
            orderById.Status = order.Status;
            if((int) order.Status < 3) orderById.QuantityDone = order.QuantityDone + orderById.QuantityDone;
            _dbContext.OrderProducts.Update(orderById);
            _dbContext.SaveChanges();

            return orderById;
        }

        public async Task<bool> delete(int id)
        {
            OrderProduct orderById = await getById(id);

            if (orderById == null)
            {
                throw new Exception($"Produto para o ID: {id} não encontrado!");
            }

            _dbContext.OrderProducts.Remove(orderById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<OrderProduct> getByMachine(int machine)
        {
            var order = await _dbContext.OrderProducts
                .Where(x => x.Machine == machine)
                .FirstOrDefaultAsync();

            return order;
        }
    }
}

