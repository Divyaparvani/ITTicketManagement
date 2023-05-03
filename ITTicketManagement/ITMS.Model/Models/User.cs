using System.ComponentModel.DataAnnotations;
namespace ITMS.Model.Models
{
    public class Users : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string MobileNo { get; set; }

    }
}


