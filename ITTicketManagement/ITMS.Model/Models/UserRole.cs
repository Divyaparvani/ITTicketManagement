using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMS.Model.Models
{
   public class UserRole: BaseEntity
    { 
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

    }
}
