using Microsoft.AspNetCore.Mvc;
using tsmxbackendStorage.Contracts;
using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class ClienteController : Controller
    {

        private readonly ICustomerRepository _customerRepo;

        public ClienteController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> getCustomers()
        {
            try
            {
                var companies = await _customerRepo.getCustomers();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createCustomer(Cliente dataCliente) 
        {
            try
            {
                var customer = await _customerRepo.createCustomers(dataCliente);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("{idCliente}")]
        public async Task<IActionResult> getCustomerIdCliente(int idCliente)
        {
            try
            {
                var customer = await _customerRepo.getCustomerIdCliente(idCliente);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }



        



    }
}
