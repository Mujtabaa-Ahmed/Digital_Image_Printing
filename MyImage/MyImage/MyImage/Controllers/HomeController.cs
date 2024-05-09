using Microsoft.AspNetCore.Mvc;
using MyImage.DB_Context;
using MyImage.Models;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using static MyImage.Models.class_accounts;

namespace MyImage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DB_context database;
        public HomeController(ILogger<HomeController> logger, DB_context data)
        {
            
            this.database = data;
            _logger = logger;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logining()
        {

            var email = Request.Form["email"].FirstOrDefault();
            var password = Request.Form["password"].FirstOrDefault();

            List<class_user_table> user_details = database.user_tables.Where(a => a.e_mail == email).ToList();
            List<class_accounts> user = database.Accounts.Where(a => a.e_mail == email && a.password == password).ToList();


            if (user.Count != 0)
            {
                
                HttpContext.Session.SetString("session_Id", user_details[0].costumer_id.ToString());
                HttpContext.Session.SetString("session_first_name", user_details[0].f_name.ToString());
                HttpContext.Session.SetString("session_last_name", user_details[0].l_name.ToString());
                HttpContext.Session.SetString("session_email", user_details[0].gander.ToString());
                HttpContext.Session.SetString("session_email", user_details[0].dob.ToString());
                HttpContext.Session.SetString("session_email", user_details[0].p_number.ToString());
                HttpContext.Session.SetString("session_email", user_details[0].addres.ToString());
                HttpContext.Session.SetString("session_email", user_details[0].e_mail.ToString());

                Class_session.user_id = user_details[0].costumer_id.ToString();
                Class_session.user_fname = user_details[0].f_name.ToString();
                Class_session.user_lname = user_details[0].l_name.ToString();
                Class_session.gander = user_details[0].gander.ToString();
                Class_session.dateOB = user_details[0].dob.ToString();
                Class_session.number = user_details[0].p_number.ToString();
                Class_session.adders = user_details[0].addres.ToString();
                Class_session.user_email = user_details[0].e_mail.ToString();
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
            var e_mail = Request.Form["mail"].ToString();
            var password = Request.Form["password"];

            List<class_accounts> valid = database.Accounts.Where(a => a.e_mail == e_mail).ToList();

            if (valid.Count == 0)
            {
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
                return Content("");
            }

            else
            {
                return Content("Email is already registered");
            }
                
        }
        public IActionResult edit_profile() 
        {
            return View();
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
