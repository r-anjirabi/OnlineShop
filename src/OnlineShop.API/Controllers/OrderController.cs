using Microsoft.AspNetCore.Mvc;
using OnlineShop.ApplicationServices;
using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;
using System.Net;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _orderService.CreateOrderAsync(req);

            return Ok();
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(List<OrderDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        [Route("payment")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> OrderPayment([FromBody] PaymentRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _orderService.PaymentAsync(req);

            return Ok();
        }

        [HttpPost]
        [Route("ship")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> OrderShip([FromBody] ShipRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _orderService.ShipAsync(req);

            return Ok();
        }
    }
}
