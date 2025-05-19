using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class RideStatus : Entity {
        public string Name { get; set; } = string.Empty;
        public ICollection<Ride> Rides { get; set; } = new List<Ride>();
    }
}
