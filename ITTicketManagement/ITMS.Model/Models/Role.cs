using System.ComponentModel.DataAnnotations;

namespace ITMS.Model.Models
{
    public  class Roles : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
