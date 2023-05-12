using System;
using System.ComponentModel.DataAnnotations;

namespace ITMS.Model.ViewModels
{
    public class RoleViewmodel
    {
       
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public RoleViewmodel()
        {
            Id = Guid.NewGuid();
        }
    }
}
