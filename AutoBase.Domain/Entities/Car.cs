using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class Car : Entity{
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public int SeatsCount { get; set; }

        public Guid CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }

        public Guid? DriverId { get; set; }
        public Driver? Driver { get; set; }

        public ICollection<Ride> Rides { get; set; }

    }
}
