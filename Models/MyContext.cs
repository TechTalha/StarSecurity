using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;

namespace StarSecurityServices.Models
{
    public class MyContext: IdentityDbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Booking> bookings { get; set; }

        public DbSet<Vacancies> vacancies { get; set; }
        public DbSet<viewmodel.login> Logins { get; set; }
        public DbSet<StarSecurityServices.Models.CctvBook> CctvBook { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Job> jobs { get; set; }
    }
}
