using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBase.Domain.Entities {
    public class RequestStatus : Entity {

        public string Name { get; set; }

        public ICollection<Request> Requests { get; set; } = new List<Request>();
    }
}
