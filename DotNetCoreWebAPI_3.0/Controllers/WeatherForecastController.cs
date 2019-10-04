using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebAPI_3._0.Data.Models;
using DotNetCoreWebAPI_3._0.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCoreWebAPI_3._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBeerRepository beerRepository)
        {
            _logger = logger;
            _beerRepository = beerRepository;
        }

        [HttpGet]
        public IEnumerable<Beer> Get()
        {
            return _beerRepository.Filter();
        }
    }
}
