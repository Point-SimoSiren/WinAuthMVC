using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinAuthMVC.Models;


// THIS WINDOWS AUTHORIZATION WORKS ONLY IN LOCALHOST, NOT IN AZURE
// IF YOU WANT TO USE THIS IN AZURE, YOU NEED TO SET UP A CUSTOM AUTHENTICATION METHOD


namespace WinAuthMVC.Controllers
{
    [Authorize] // Ensure that the user is authenticated (Any Windows user)
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // Check if the user is authenticated and has a specific username
            if (User.Identity?.Name! == "DUUNIKONE\\Simo")
            {

                return View();
            }
            else
            {
                
                return View("Index");
            }
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
