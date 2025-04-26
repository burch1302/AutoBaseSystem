using AutoBase.Domain;
using AutoBase.Domain.Entities;
using AutoBaseSystem.Models.RequestViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoBaseSystem.Controllers {
    [Authorize]
    public class RequestController : BaseController {
        private readonly AutoBaseSystemContext _context;

        public RequestController(AutoBaseSystemContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var requests = _context.Requests
                .Include(r => r.CarCategory)
                .Include(r => r.RequestStatus)
                .ToList();

            ViewBag.Statuses = _context.RequestStatuses
                .Select(s => new SelectListItem {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();

            return View(requests);
        }


        [HttpGet]
        public IActionResult Create() {
            var categories = _context.Set<CarCategory>()
                .Select(c => new SelectListItem {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            var model = new RequestCreateViewModel {
                AvailableCategories = categories
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(RequestCreateViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var request = new AutoBase.Domain.Entities.Request {
                ArrivalTime = model.ArrivalTime,
                PassengersCount = model.PassengersCount,
                CarCategoryId = model.CarCategoryId,
                //Нова , мабудь краще було б зробити класс-констант
                RequestStatusId = Guid.Parse("DDECDDBB-7C6D-4CD1-9120-68624C6808A2")
            };

            _context.Requests.Add(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Dispatcher,Admin")]
        public IActionResult UpdateStatus(Guid requestId, Guid statusId) {
            var request = _context.Requests.FirstOrDefault(r => r.Id == requestId);
            if (request != null) {
                request.RequestStatusId = statusId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
