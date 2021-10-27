using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandologic.DAL;
using Pandologic.Entities;

namespace Pandologic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;

        public JobController(ILogger<JobController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Search")]
        public IEnumerable<Job> Search([FromQuery] int value)
        {
            if (value < 1)
            {
                return new List<Job>();
            }

            var repository = Factory.GetJobFetcher();

            return repository.Fetch(value);
        }
    }
}
