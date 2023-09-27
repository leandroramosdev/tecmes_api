using System;
using TecmesAPI.Enums;
using TecmesAPI.Models;

namespace TecmesAPI.Services.Interfaces
{
    public interface IOrderProductService
	{
        Task<IEnumerable<OrderProduct>> getAll();
        Task<OrderProduct> getById(int id);
        Task<OrderProduct> add(OrderProduct orderProduct);
        Task<OrderProduct> update(OrderProduct orderProduct, int id);
        Task<bool> delete(int id);

        Task<OrderProduct> getByMachine(int machine);
    }
}

