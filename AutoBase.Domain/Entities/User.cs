using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class User : Entity {
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }
        public UserRole Role { get; set; }

    }
}
