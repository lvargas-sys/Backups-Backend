using Microsoft.AspNetCore.Mvc;
using tsmxbackendStorage.Contracts;
using tsmxbackendStorage.Entities;

namespace tsmxbackendStorage.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepo;

        public JobController(IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;

        }

        [HttpGet]
        public async Task<IActionResult> getJobs()
        {
            try
            {
                var job = await _jobRepo.getJob();
                return Ok(job);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> createJob(JobLog dataJob)
        {
            try
            {
                var customer = await _jobRepo.createJob(dataJob);
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
