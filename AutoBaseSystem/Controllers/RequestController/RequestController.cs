using AutoBase.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoBaseSystem.Controllers {
    [Authorize(Roles = "Dispatcher,Admin")]
    public class RequestController : BaseController {
        private readonly AutoBaseSystemContext _context;

        public RequestController(AutoBaseSystemContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var requests = _context.Requests
                .Include(r => r.CarCategory)
                .ToList();

            return View(requests);
        }
    }
}
