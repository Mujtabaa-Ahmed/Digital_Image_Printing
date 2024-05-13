using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MyImage.DB_Context;
using MyImage.Models;

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
        public IActionResult testing(class_subCategeory subway)
        {
            string subcat = Request.Form["forsubcat"];
            string product = Request.Form["forproduct"];

            class_subCategeory testing_for = new class_subCategeory()
            {
                subCat_name = subcat,
                cat_id = 1,
                subCat_status = 0
            };
            database.Add(testing_for);
            database.SaveChanges();
            var getcat = database.subCategeories.FirstOrDefault(a => a.subCat_name == subcat);
            class_services services = new class_services()
            {
                service_name = product,
                subCat_id = getcat.subCat_id,
                cat_id = getcat.cat_id,
                service_price = 2000,
                service_cancledprice = 3000,
                service_description = "asdasdasdasdasdasda",

            };
            database.Add(services);
            database.SaveChanges();
            return Content(product);
        }
    }
}
