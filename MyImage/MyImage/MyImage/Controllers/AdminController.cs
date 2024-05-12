using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MyImage.DB_Context;

namespace MyImage.Controllers
{
    public class AdminController : Controller
    {
        private  readonly ILogger<AdminController> _logger;
        private DB_context database;
        public AdminController(ILogger<AdminController> logger, DB_context data)
        {
            _logger = logger;
            this.database = data;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult add_service() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult testing()
        {
            string subcat = Request.Form["forsubcat"];
            string product = Request.Form["forproduct"];

            return Content(subcat, product);
        }
    }
}
