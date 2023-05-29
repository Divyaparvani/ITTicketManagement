using ITMS.Model.Models;
using System.ComponentModel.DataAnnotations;

namespace ITMS.Model.ViewModels
{
    public class CommonLookUpViewModel : BaseEntity
    {
        [Required(ErrorMessage = "ConfigName is Required")]
        public string ConfigName { get; set; }
        [Required(ErrorMessage = "Configkey is Required")]
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
    }
}
