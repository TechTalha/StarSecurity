using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StarSecurityServices.viewmodel;
using System;
using System.Threading.Tasks;
using StarSecurityServices.Models;
using System.Linq;

namespace StarSecurityServices.Controllers
{
    public class IndexController : Controller
    {
        MyContext myContext;

        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        public IndexController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,MyContext mycontext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            myContext = mycontext;
            


        }
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contacts( Contact c)
        {
            myContext.contacts.Add(c);
            myContext.SaveChanges();
            ViewBag.message = "Data Inserted";

            return View();
        }
        public IActionResult Career()
        {
            return View(myContext.vacancies.ToList());
        }
        public IActionResult Clients()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.UserName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Register", "Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }




            }

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(login model)
        {
           
            
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    Console.WriteLine(result);
                    if (result.Succeeded)
                    {
                    return RedirectToAction("userdashboard", "Dashboard");
                    //if (model.UserName == "Talha")
                    //{
                    //    return RedirectToAction("Index", "Index");
                    //}else
                    //{
                    //    return RedirectToAction("Dashboard", "userdashboard")
                    //}
                }
                    if(model.UserName == "Admin"  && model.Password == "TALHA1234a.")
                    {
                    return RedirectToAction("Create","Dashboard");
                    }
                     else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login");
                    }
                



            }
            
           

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Site()
        {
            return View();
        }


    }
}
