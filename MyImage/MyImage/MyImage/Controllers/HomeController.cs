using Microsoft.AspNetCore.Mvc;
using MyImage.DB_Context;
using MyImage.Models;
using System.Diagnostics;
using static MyImage.Models.class_accounts;

namespace MyImage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DB_context database;
        public HomeController(ILogger<HomeController> logger, DB_context data)
        {
            
            database = data;
            _logger = logger;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logining()
        {
            var e_mail = Request.Form["email"].FirstOrDefault();
            var password = Request.Form["password"].FirstOrDefault();
            List<class_accounts> user = database.Accounts.Where(a => a.e_mail == e_mail && a.password == password).ToList();
            if (user.Count != 0)
            {
                HttpContext.Session.SetString("session_Id", user[0].signin_id.ToString());
                HttpContext.Session.SetString("session_first_name", user[0].first_name.ToString());
                HttpContext.Session.SetString("session_last_name", user[0].last_name.ToString());
                HttpContext.Session.SetString("session_email", user[0].e_mail.ToString());

                Class_session.user_id = user[0].signin_id.ToString();
                Class_session.user_fname = user[0].first_name.ToString();
                Class_session.user_lname = user[0].last_name.ToString();
                Class_session.user_email = user[0].e_mail.ToString();


                return Content("Loged In");
            }
            else 
            {
                return Content("E-mail or Password is incorrect");
            }
        }
        public IActionResult logout() 
        {
            HttpContext.Session.Clear();
            Class_session.user_email = "";
            Class_session.user_fname = "";
            Class_session.user_lname = "";
            Class_session.user_id = "";

            return RedirectToAction(nameof(Index));
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signingup() 
        {

            var first_name = Request.Form["first"];
            var last_name = Request.Form["last"];
            var e_mail = Request.Form["mail"];
            var password = Request.Form["password"];
            
            class_accounts signups = new class_accounts() 
            {
                first_name = first_name,
                last_name = last_name,
                e_mail = e_mail,
                password = password
            };



            List<class_accounts> getId = new List<class_accounts>();
            var gtt = getId.FirstOrDefault(a => a.first_name == first_name);

            class_user_table user = new class_user_table()
            {
                f_name = first_name,
                l_name = last_name,
                addres = "-",
                dob = "-",
                gander = "-",
                p_number = 00000,
                e_mail = e_mail
            };


            database.Add(signups);
            database.SaveChanges();
            database.Add(user);
            database.SaveChanges();
            return Content("bhai bht aala");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult cart()
        {
            return View();
        }
        public IActionResult About() 
        {
            return View();
        }
        public IActionResult Contact() 
        {
            return View();
        }
        public IActionResult Privacy()
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
