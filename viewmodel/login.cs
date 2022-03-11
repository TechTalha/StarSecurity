using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.viewmodel
{

    public class login
    {
        [Key]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
