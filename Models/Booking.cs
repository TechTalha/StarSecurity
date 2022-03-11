using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string No_of_Guards { get; set; }
        public string Area { get; set; }
        public string Contact { get; set; }
        public string Category { get; set; }
        public string Weapon { get; set; }
        public string City { get; set; }
        public string Add_info { get; set; }
    }
}
