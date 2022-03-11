using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Vacancies
    {
        [Key]
        public int Id { get; set; }
        public string Job_Title { get; set; }
        public string Department { get; set; }
        public string opening_Date { get; set; }
        public string Duty_Station { get; set; }
    }
}
