using Microsoft.AspNetCore.Authorization;
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
        
        [Authorize(Roles = "User,Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult add_admin(string message) 
        {
            ViewBag.error = message;
            return View();
        }
        public IActionResult adding_admin() 
        {
            var first_name = Request.Form["first_name"];
            var last_name = Request.Form["last_name"];
            var e_mail = Request.Form["e_mail"].ToString();
            var password = Request.Form["password"];
            var cpassword = Request.Form["confirm_password"];

            List<class_accounts> valid = database.Accounts.Where(a => a.e_mail == e_mail).ToList();

            if (valid.Count == 0)
            {
                if (password == cpassword)
                {
                    class_accounts signups = new class_accounts()
                    {
                        first_name = first_name,
                        last_name = last_name,
                        e_mail = e_mail,
                        password = password,
                        roles_id = 2
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
                        e_mail = e_mail,
                        Profile_photo = ""
                    };


                    database.Add(signups);
                    database.Add(user);
                    database.SaveChanges();
                    return RedirectToAction("add_admin", "Admin", new { message = "Loged In" });
                }
                else 
                {
                    return RedirectToAction("add_admin", "Admin", new { message = "Error" });
                }
            }
            else
            {
                return Content("Email is already registered");
            }

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
