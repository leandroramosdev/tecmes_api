using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TecmesAPI.Enums;
using TecmesAPI.Models;
using TecmesAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TecmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {

        private readonly IOrderProductService _orderProductService;

        public OrderProductsController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<OrderProduct>>> getAll()
        {
            IEnumerable<OrderProduct> orders = await _orderProductService.getAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderProduct>> getById(int id)
        {
            OrderProduct order = await _orderProductService.getById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderProduct>> add([FromBody] OrderProduct order)
        {
            OrderProduct result = await _orderProductService.add(order);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderProduct>> update([FromBody] OrderProduct order, int id)
        {
            order.Id = id;
            OrderProduct result = await _orderProductService.update(order, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> delete(int id)
        {
            Boolean result = await _orderProductService.delete(id);
            return Ok(result);
        }

        [HttpGet("/api/OrderProducts/getByMachine")]
        public async Task<ActionResult<OrderProduct>> getByMachine([FromQuery] int machine)
        {
            OrderProduct order = await _orderProductService.getByMachine(machine);
            return Ok(order);
        }


    }
}

