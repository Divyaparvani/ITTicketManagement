using ITMS.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ITMS.Model.ViewModels
{
    public  class UserViewModel : BaseEntity
    {
        [Required(ErrorMessage ="FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
       
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string MobileNo { get; set; }

        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public List<DropDown> RoleDropDown { get; set; }
        public string RoleName { get; set; }
    }
}
