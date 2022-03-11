using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Controllers
{

    public class DashboardController : Controller
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        MyContext myContext;


        public DashboardController(MyContext mycontext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            myContext = mycontext;
        }
        public async Task <IActionResult> Index()
        {
            return View(await myContext.vacancies.ToListAsync()); 
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create([Bind("EmpName,EmpAdd,EmpCon,EmpEdu,Depart,Role,Grade")] Vacancies vacancies)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(vacancies);
                await myContext.SaveChangesAsync();
                return RedirectToAction(nameof(Create));

            }
            return View(vacancies);
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Vacancies vacancies = myContext.vacancies.Where(a => a.Id == Id).FirstOrDefault();
            return View(vacancies);
        }
        [HttpPost]
        public IActionResult Delete(Models.Vacancies vacancies)
        {
            var result = myContext.vacancies.Where(a => a.Id == vacancies.Id).FirstOrDefault();
            if (result != null)
            {
               myContext.vacancies.Remove(result);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult booking()
        {
            return View(myContext.bookings.ToList());
        }  
        public IActionResult booking2()
        {
            return View(myContext.bookings.ToList());
        }    
        public IActionResult booking3()
        {
            return View(myContext.CctvBook.ToList());
        }
        public IActionResult login()
        {
            return View(myContext.Logins.ToList());
        }
        public IActionResult userdashboard()
        {
            return View(myContext.bookings.ToList());
        }
        public IActionResult ccuserdash()
        {
            return View(myContext.CctvBook.ToList());
        }
        public IActionResult Contact()
        {
            return View(myContext.contacts.ToList());
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


    }
}
