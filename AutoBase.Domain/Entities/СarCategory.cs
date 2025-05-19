using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class CarCategory : Entity{
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
