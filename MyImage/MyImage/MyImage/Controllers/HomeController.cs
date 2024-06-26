﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyImage.DB_Context;
using MyImage.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using static MyImage.Models.class_accounts;
using static MyImage.Models.class_listModels;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Authorization;

namespace MyImage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DB_context database;
        public class_listModels dataset = new class_listModels();
        public HomeController(ILogger<HomeController> logger, DB_context data)
        {
            this.database = data;
            _logger = logger;
            dataset.categeories = database.categeories.ToList();
            dataset.SubCategeories = database.subCategeories.ToList();
            dataset.SubCategeoriesForMenue = database.subCategeories.Where(a => a.subCat_status == 1).ToList();
            dataset.userTable = database.user_tables.Where(a => a.e_mail == Class_session.user_email).ToList();
            dataset.price = database.prices.ToList();
            dataset.size = database.sizes.ToList();
        }
        public IActionResult LogIn()
        {
            return View(dataset);
        }
        [HttpPost]
        public IActionResult Logining()
        {

            var email = Request.Form["email"].ToString();
            var password = Request.Form["password"].ToString();

            var user_details = database.user_tables.FirstOrDefault(a => a.e_mail == email);
            var user = database.Accounts.FirstOrDefault(a => a.e_mail == email && a.password == password);

            ClaimsIdentity Identity = null;
            bool isAuthenticate = false;
            if (user != null)
            {
                if (user.roles_id == 2)
                {
                    Identity = new ClaimsIdentity(
                        new[]
                           {
                             new Claim(ClaimTypes.Email , user.e_mail ),
                             new Claim(ClaimTypes.Role , "Admin")
                           }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                    HttpContext.Session.SetString("session_Id", user_details.costumer_id.ToString());
                    HttpContext.Session.SetString("session_first_name", user_details.f_name.ToString());
                    HttpContext.Session.SetString("session_last_name", user_details.l_name.ToString());
                    HttpContext.Session.SetString("session_email", user_details.gander.ToString());
                    HttpContext.Session.SetString("session_email", user_details.dob.ToString());
                    HttpContext.Session.SetString("session_email", user_details.p_number.ToString());
                    HttpContext.Session.SetString("session_email", user_details.addres.ToString());
                    HttpContext.Session.SetString("session_email", user_details.e_mail.ToString());
                    HttpContext.Session.SetString("profile", user_details.Profile_photo.ToString());

                    Class_session.user_id = user_details.costumer_id.ToString();
                    Class_session.user_fname = user_details.f_name.ToString();
                    Class_session.user_lname = user_details.l_name.ToString();
                    Class_session.gander = user_details.gander.ToString();
                    Class_session.dateOB = user_details.dob.ToString();
                    Class_session.number = user_details.p_number.ToString();
                    Class_session.adders = user_details.addres.ToString();
                    Class_session.user_email = user_details.e_mail.ToString();
                    Class_session.image = user_details.Profile_photo.ToString();
                }
                if (user.roles_id == 1)
                {
                    Identity = new ClaimsIdentity(
                        new[]
                           {
                             new Claim(ClaimTypes.Email , user.e_mail ),
                             new Claim(ClaimTypes.Role , "User")
                           }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                    HttpContext.Session.SetString("session_Id", user_details.costumer_id.ToString());
                    HttpContext.Session.SetString("session_first_name", user_details.f_name.ToString());
                    HttpContext.Session.SetString("session_last_name", user_details.l_name.ToString());
                    HttpContext.Session.SetString("session_email", user_details.gander.ToString());
                    HttpContext.Session.SetString("session_email", user_details.dob.ToString());
                    HttpContext.Session.SetString("session_email", user_details.p_number.ToString());
                    HttpContext.Session.SetString("session_email", user_details.addres.ToString());
                    HttpContext.Session.SetString("session_email", user_details.e_mail.ToString());
                    HttpContext.Session.SetString("profile", user_details.Profile_photo.ToString());

                    Class_session.user_id = user_details.costumer_id.ToString();
                    Class_session.user_fname = user_details.f_name.ToString();
                    Class_session.user_lname = user_details.l_name.ToString();
                    Class_session.gander = user_details.gander.ToString();
                    Class_session.dateOB = user_details.dob.ToString();
                    Class_session.number = user_details.p_number.ToString();
                    Class_session.adders = user_details.addres.ToString();
                    Class_session.user_email = user_details.e_mail.ToString();
                    Class_session.image = user_details.Profile_photo.ToString();
                }
                if (isAuthenticate)
                {
                    var principle = new ClaimsPrincipal(Identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                    if (user.roles_id == 2) //for admin
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (true) //for user
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return RedirectToAction(nameof(LogIn));



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
            return View(dataset);
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
                    password = password,
                    roles_id = 1
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
                return Content("");
            }

            else
            {
                return Content("Email is already registered");
            }

        }
        public IActionResult edit_profile()
        {
            return View(dataset);
        }
        [HttpPost]
        public IActionResult edit_pro(IFormFile File)
        {


            var FirstName = Request.Form["fname"].ToString();
            var LastName = Request.Form["lname"].ToString();
            var PhoneNumber = Request.Form["num"].ToString();
            var Adress = Request.Form["adress"].ToString();
            var BD = Request.Form["dob"].ToString();
            var Gander = Request.Form["gander"].ToString();
            var img = Request.Form["Pimg"].ToString();


            if (File != null)
            {
                string filename = Path.Combine(DateTime.Now.ToString("MMddhhmmss") + File.FileName);
                string filepath = Path.Combine("wwwroot/img/UploadedImages/", filename);


                var userw = database.user_tables.FirstOrDefault(x => x.e_mail == Class_session.user_email);
                if (userw != null)
                {
                    userw.f_name = FirstName;
                    userw.l_name = LastName;
                    userw.p_number = Int64.Parse(PhoneNumber);
                    userw.addres = Adress;
                    userw.dob = BD;
                    userw.gander = Gander;
                    userw.Profile_photo = "~/img/UploadedImages/" + filename;
                    database.Update(userw);
                }

                Class_session.image = "~/img/UploadedImages/" + filename;

                using (var strem = new FileStream(filepath, FileMode.Create))
                {
                    File.CopyTo(strem);
                }
            }
            else
            {
                var user = database.user_tables.FirstOrDefault(x => x.e_mail == Class_session.user_email);
                if (user.Profile_photo != "")
                {
                    user.f_name = FirstName;
                    user.l_name = LastName;
                    user.p_number = Int64.Parse(PhoneNumber);
                    user.addres = Adress;
                    user.dob = BD;
                    user.Profile_photo = img;
                    user.gander = Gander;
                    database.Update(user);
                }
                else
                {
                    user.f_name = FirstName;
                    user.l_name = LastName;
                    user.p_number = Int64.Parse(PhoneNumber);
                    user.addres = Adress;
                    user.dob = BD;
                    user.Profile_photo = "";
                    user.gander = Gander;
                    database.Update(user);
                }
            }





            var account = database.Accounts.FirstOrDefault(x => x.e_mail == Class_session.user_email);
            if (account != null)
            {
                account.first_name = FirstName;
                account.last_name = LastName;

                database.Update(account);
            }

            Class_session.user_fname = FirstName;
            Class_session.user_lname = LastName;
            Class_session.number = PhoneNumber;
            Class_session.adders = Adress;
            Class_session.dateOB = BD;
            Class_session.gander = Gander;



            database.SaveChanges();


            return RedirectToAction(nameof(Index));


        }
        public IActionResult Index()
        {
            return View(dataset);
        }
        [HttpGet]
        public IActionResult product(string subcat)
        {
            
            
            var serv = database.services.Where(a => a.subCat_id == int.Parse(subcat)).ToList();
            
            dataset.service = serv;
            ViewBag.subcat = subcat;
            return View(dataset);
            
            
        }
        [HttpPost]
        public IActionResult size_s()
        {
            var selected_size = Request.Form["selected_size"].FirstOrDefault();

            List<class_sizes> selected_one = database.sizes.Where(a => a.size == selected_size).ToList();
            selected.Ssize = selected_one[0].size;
            List<class_prices> selected_one_price = database.prices.Where(a => a.size_id == selected_one[0].size_id).ToList();
            selected.Sprice = selected_one_price[0].prices.ToString();
            selected.Scprice = selected_one_price[0].cancleed_prices.ToString();


            return Content("gotit");
        }
        public IActionResult chackout()
        {
            var Ctype = Request.Form["type"].ToString();
            var number = Request.Form["card_number"].ToString();
            var Vnumber = Request.Form["VCard"].ToString();

            if (Class_session.user_id != "")
            {
                string date = DateTime.Now.ToString("dd-MMM-yyyy");
                string invoice = DateTime.Now.ToString("yyyyMMddHHmmss");
                string user = Class_session.user_id.ToString();
                int amount = 0;

                foreach (class_cart values in list.carts)
                {
                    amount = amount + int.Parse(values.service_price) * int.Parse(values.service_quantity);

                    class_order_details details = new class_order_details() 
                    {
                        user_id = user,
                        order_date = date,
                        order_invoice = invoice,
                        order_service = values.service_name,
                        user_uploaded_image = values.image_stored,
                        order_quantity = values.service_quantity
                    };
                    database.Add(details);
                    database.SaveChanges();
                }

                class_orders order = new class_orders() 
                { 
                    user_id = user,
                    order_date = date,
                    order_invoice = invoice,
                    card_type = Ctype,
                    card_number = number,
                    V_car_number = Vnumber,
                    order_total_amount = amount.ToString()
                };
                database.Add(order);
                database.SaveChanges();

                list.carts.Clear();

                return RedirectToAction("cart", "Home", dataset);
            }
            return RedirectToAction("cart", "Home", dataset);

        }
        public IActionResult services() 
        {
            return View(dataset);
        }
        public IActionResult comming_soon() 
        {
            return View(dataset);
        }
        public IActionResult blogs() 
        {
            return View(dataset);
        }
        public IActionResult cart()
        {
            return View(dataset);
        }
        public IActionResult add_cart(class_cart a,IFormFile image_for_printing) 
        {
            if (image_for_printing != null)
            {
                string filename = Path.Combine(DateTime.Now.ToString("MMddhhmmss") +"uploaded_image"+ image_for_printing.FileName);
                string filepath = Path.Combine("wwwroot/img/cart/", filename);
                string file = Path.GetFileNameWithoutExtension(filename);






                   class_cart cart_item = new class_cart()
                   {
                        service_id = a.service_id,
                      service_name = a.service_name,
                       service_price = a.service_price,
                       service_size = a.service_size,
                       service_quantity = a.service_quantity.ToString(),
                        image_stored = filename,
                        cart_id = file
                    };
                    list.carts.Add(cart_item);
                
                using (var strem = new FileStream(filepath, FileMode.Create))
                {
                    image_for_printing.CopyTo(strem);
                }
                return RedirectToAction("product", "Home", new { subcat = a.service_id });





            }
            else { return Content("not moved"); }
            
            //return RedirectToAction("product","Home",new { subcat = a.service_id});
        }
        [HttpPost]
        public IActionResult update_cart()
        {
            var qty = Request.Form["quantity"].FirstOrDefault();
            var id = Request.Form["item_id"].FirstOrDefault();

            var model = list.carts.FirstOrDefault(a => a.cart_id == id);

            if (model != null) 
            {
                model.service_quantity = qty;
            }
            return Content("updated");
        }
        public IActionResult delete_cart(string id) 
        {
            var deleting = list.carts.FirstOrDefault(a => a.cart_id == id);

            if (deleting != null)
            {

                string dfile = "wwwroot/img/cart/";
                string file = deleting.image_stored;

                System.IO.File.Delete(dfile + file);
                list.carts.Remove(deleting);

            }

            return RedirectToAction("cart","Home", dataset);
        }
        public IActionResult About() 
        {
            return View(dataset);
        }
        public IActionResult Contact() 
        {
            return View(dataset);
        }
        public IActionResult Privacy()
        {
            return View(dataset);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
