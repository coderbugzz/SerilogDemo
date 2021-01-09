using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("This is the Home Page");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy Page");


            try
            {
                throw new Exception("Error in Privacy page");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This excemption is in Privacy page");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
