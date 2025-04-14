using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class TripReport : Entity{
        public Guid RideId { get; set; }
        public Ride Ride { get; set; }

        public double FuelUsedLiters { get; set; }
        public string? Notes { get; set; }
        public DateTime CompletedAt { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
