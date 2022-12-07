using Microsoft.AspNetCore.Mvc;
using tsmxbackendStorage.Contracts;
using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Controllers
{
    [Route("api/device")]
    [ApiController]
    public class DispositivoController : Controller
    {
        private readonly IDispositivoRepository _deviceRepo;

        public DispositivoController(IDispositivoRepository deviceRepo)
        {
            _deviceRepo = deviceRepo;

        }

        [HttpGet]
        public async Task<IActionResult> getDevices()
        {
            try
            {
                var companies = await _deviceRepo.getDevices();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createDevice(Dispositivo dataDispositivo)
        {
            try
            {
                var customer = await _deviceRepo.createDevice(dataDispositivo);
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
