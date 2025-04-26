using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class Ride : Entity{
        public Guid RequestId { get; set; }
        public Request Request { get; set; }

        public Guid DriverId { get; set; }
        public Driver Driver { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool IsCompleted { get; set; }

        public TripReport TripReport { get; set; }
        public Guid RideStatusId { get; set; }
        public RideStatus RideStatus { get; set; }
    }
}
