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
    public class JobTitleController : ControllerBase
    {
        private readonly ILogger<JobTitleController> _logger;

        public JobTitleController(ILogger<JobTitleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Search")]
        public IEnumerable<JobTitle> Search([FromQuery] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new List<JobTitle>();
            }

            var repository = Factory.GetJobTitleFetcher();

            return repository.Fetch(value);
        }
    }
}
