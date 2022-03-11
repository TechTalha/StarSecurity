using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public string Education { get; set; }
        public string Previous_Experience { get; set; }
        public string City { get; set; }
    }
}
