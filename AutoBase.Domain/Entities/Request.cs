using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class Request : Entity {
        public DateTime ArivalTime { get; set; }
        public int PassengersCount { get; set; }

        public Guid CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }

        public Ride Ride { get; set; }
    }
}
