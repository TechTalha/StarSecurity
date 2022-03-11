using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StarSecurityServices.Models;
using System.Threading.Tasks;

namespace StarSecurityServices.Controllers
{
    public class BookingController : Controller
    {
        MyContext myContext;

        private readonly IConfiguration configuration;

        public BookingController(IConfiguration config, MyContext mycontext)
        {
            this.configuration = config;
            myContext = mycontext;

        }
        public IActionResult Index()
        {
            string connectionstring = configuration.GetConnectionString("con");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand com = new SqlCommand("Select count(*) from bookings",connection);
            var count = (int)com.ExecuteScalar();

            ViewData["TotalData"] = count;
            connection.Close();
            return View();
        }
        public IActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking([Bind("Name,Email,No_of_Guards,Area,Contact,Category,Weapon,City,Add_info")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(booking);
                await myContext.SaveChangesAsync();
                return RedirectToAction(nameof(Booking));

            }
            return View(booking);
        }
        public IActionResult Booking2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking2([Bind("Name,Email,No_of_Guards,Area,Contact,Category,Weapon,City,Add_info")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(booking);
                await myContext.SaveChangesAsync();
                return RedirectToAction(nameof(Booking2));

            }
            return View(booking);
        }
        public IActionResult Booking3()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking3([Bind("Name,Email,Contact_No,Product,City,Additional_Info")] CctvBook cctvBook)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(cctvBook);
                await myContext.SaveChangesAsync();
                return RedirectToAction(nameof(Booking3));

            }
            return View(cctvBook);
        }

    }
}
