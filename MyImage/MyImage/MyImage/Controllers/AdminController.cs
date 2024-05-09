using Microsoft.AspNetCore.Mvc;
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
    }
}
