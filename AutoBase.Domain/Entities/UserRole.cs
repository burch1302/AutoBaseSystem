using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class UserRole : Entity{
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
