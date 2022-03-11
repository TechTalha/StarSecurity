using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class CctvBook
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact_No { get; set; }
        public string Product { get; set; }
        public string City { get; set; }
        public string Additional_Info  { get; set; }
    }              
}
