using FirstMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVCProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ContactController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult AddContacts()
        {
            return View();
        }

        public IActionResult EditContacts()
        {
            return View();
        }

        public IActionResult DeleteContacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}