using Microsoft.AspNetCore.Mvc;
using OnlineShop.ApplicationServices;
using OnlineShop.ApplicationServices.DTO;
using OnlineShop.ApplicationServices.Request;
using System.Net;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerService.AddCustomerAsync(req);

            return Ok();
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(List<CustomerDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _customerService.GetAllCustomersAsync();
            return Ok(orders);
        }
    }
}
