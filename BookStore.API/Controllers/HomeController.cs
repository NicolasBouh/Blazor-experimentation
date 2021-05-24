using BookStore.API.Contracts;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.API.Controllers
{
    /// <summary>
    /// This is a test API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILoggerService _logger;

        public HomeController(ILoggerService logger)
        {
            _logger = logger;
        }



        /// <summary>
        /// Home Message
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInfo("Accessed to Home Controller");
            return Ok("Hello World");
        }
    }
}
