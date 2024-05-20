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
        public IActionResult login() 
        {
            return View();
        }
        public IActionResult Logining(class_accounts a)
        {

           
            List<class_user_table> user_details = database.user_tables.Where(a => a.e_mail == a.e_mail).ToList();
            List<class_accounts> user = database.Accounts.Where(a => a.e_mail == a.e_mail && a.password == a.password).ToList();


            if (user.Count != 0)
            {

                if (user[0].roles_id == 2)
                {
                    HttpContext.Session.SetString("session_Id", user_details[0].costumer_id.ToString());
                    HttpContext.Session.SetString("session_first_name", user_details[0].f_name.ToString());
                    HttpContext.Session.SetString("session_last_name", user_details[0].l_name.ToString());
                    HttpContext.Session.SetString("session_email", user_details[0].gander.ToString());
                    HttpContext.Session.SetString("session_email", user_details[0].dob.ToString());
                    HttpContext.Session.SetString("session_email", user_details[0].p_number.ToString());
                    HttpContext.Session.SetString("session_email", user_details[0].addres.ToString());
                    HttpContext.Session.SetString("session_email", user_details[0].e_mail.ToString());
                    HttpContext.Session.SetString("profile", user_details[0].Profile_photo.ToString());

                    Class_session.user_id = user_details[0].costumer_id.ToString();
                    Class_session.user_fname = user_details[0].f_name.ToString();
                    Class_session.user_lname = user_details[0].l_name.ToString();
                    Class_session.gander = user_details[0].gander.ToString();
                    Class_session.dateOB = user_details[0].dob.ToString();
                    Class_session.number = user_details[0].p_number.ToString();
                    Class_session.adders = user_details[0].addres.ToString();
                    Class_session.user_email = user_details[0].e_mail.ToString();
                    Class_session.image = user_details[0].Profile_photo.ToString();
                    return RedirectToAction("Index","Admin");
                }
                else 
                {
                    return Content("no baba");
                }

                
            }
            else
            {
                return RedirectToAction(nameof(login));
            }


        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCate() 
        {
            var cate = database.categeories.ToList();
            ViewBag.categeories = cate;
            return View();
        }
        public IActionResult addingcategeory(class_categeory c) 
        {
            database.Add(c);
            database.SaveChanges();
            return RedirectToAction(nameof(AddCate));
        }
        public IActionResult CDelete(int? id) 
        {
            var deletecat = database.categeories.FirstOrDefault(a => a.cat_id == id);
            database.Remove(deletecat);
            database.SaveChanges();
            return RedirectToAction(nameof(AddCate));
        }
        public IActionResult add_service() 
        {
            var cate = database.categeories.ToList();
            ViewBag.cate = cate;
            return View();
        }
        [HttpPost]
        public IActionResult add__() 
        {
            var service = Request.Form["service_name"].ToString();
            var dess = Request.Form["dess"].ToString();
            var categeory = Request.Form["cate"].ToString();
            var siz = Request.Form["size"].ToString();
            var siz1 = Request.Form["size1"].ToString();
            var siz2 = Request.Form["size2"].ToString();
            var siz3 = Request.Form["size3"].ToString();
            var pri1 = Request.Form["price1"].ToString();
            var pri2 = Request.Form["price2"].ToString();
            var pri3 = Request.Form["price3"].ToString();
            var pri4 = Request.Form["price4"].ToString();
            var cpri1 = Request.Form["cprice1"].ToString();
            var cpri2 = Request.Form["cprice2"].ToString();
            var cpri3 = Request.Form["cprice3"].ToString();
            var cpri4 = Request.Form["cprice4"].ToString();

            
            class_subCategeory subcat = new class_subCategeory()
            {
                subCat_name = service,
                cat_id = int.Parse(categeory)
            };
            database.Add(subcat);
            database.SaveChanges();

            var sendedsubcat = database.subCategeories.Where(a => a.subCat_name == service).ToList();
            class_services serv = new class_services()
            {
                service_name = service,
                service_description = dess,
                subCat_id = sendedsubcat[0].subCat_id,
                cat_id = int.Parse(categeory),
                service_image = ""
            };
            database.Add(serv);
            database.SaveChanges();

            var sendedservice = database.services.Where(a => a.service_name == service).ToList();
            if (siz != "") 
            {
                class_sizes six = new class_sizes()
              {
                   size = siz,
                    service_id = sendedservice[0].service_id
                };
                database.Add(six);
                database.SaveChanges();

                var sib = database.sizes.Where(a => a.size == siz).ToList();
                class_prices rp = new class_prices()
                {
                    prices = int.Parse(pri1),
                    cancleed_prices = int.Parse(cpri1)
                };
            }
            if (siz1 != "") 
            {
                class_sizes six = new class_sizes()
                {
                    size = siz1,
                    service_id = sendedservice[0].service_id
                };
                database.Add(six);
                database.SaveChanges();

                var sib = database.sizes.Where(a => a.size == siz).ToList();
                class_prices rp = new class_prices()
                {
                    prices = int.Parse(pri2),
                    cancleed_prices = int.Parse(cpri2)
                };

            }
            if (siz2 != "")
            {
                class_sizes six = new class_sizes()
                {
                    size = siz2,
                    service_id = sendedservice[0].service_id
                };
                database.Add(six);
                database.SaveChanges();

                var sib = database.sizes.Where(a => a.size == siz).ToList();
                class_prices rp = new class_prices()
                {
                    prices = int.Parse(pri3),
                    cancleed_prices = int.Parse(cpri3)
                };
            }
            if (siz3 != "")
            {
                class_sizes six = new class_sizes()
                {
                    size = siz3,
                    service_id = sendedservice[0].service_id
                };
                database.Add(six);
                database.SaveChanges();

                var sib = database.sizes.Where(a => a.size == siz).ToList();
                class_prices rp = new class_prices()
                {
                    prices = int.Parse(pri4),
                    cancleed_prices = int.Parse(cpri4)
                };
            }
           
            return RedirectToAction(nameof(add_service));
        }
        public IActionResult services() 
        {
            var services = database.services.ToList();
            ViewBag.services = services;
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
                

            };
            database.Add(services);
            database.SaveChanges();
            return Content(product);
        }
    }
}
