using AutoBase.Domain;
using AutoBase.Domain.Entities;
using AutoBaseSystem.Models.RequestViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AutoBaseSystem.Controllers {
    [Authorize]
    public class RequestController : BaseController {
        private readonly AutoBaseSystemContext _context;

        public RequestController(AutoBaseSystemContext context) {
            _context = context;
        }

        public IActionResult Index() {
            ViewBag.Error = TempData["Error"];

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

        /*[HttpPost]
        [Authorize(Roles = "Dispatcher,Admin")]
        public IActionResult UpdateStatus(Guid requestId, Guid statusId) {
            var request = _context.Requests.FirstOrDefault(r => r.Id == requestId);

            if (request != null) {
                request.RequestStatusId = statusId;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }*/
        [HttpPost]
        [Authorize(Roles = "Dispatcher,Admin")]
        public IActionResult UpdateStatus(Guid requestId, Guid statusId) {
            var acceptedStatusId = Guid.Parse("47181F52-FA9E-4A9B-A4FC-3CAE1EEEC2D2");
            var planningStatusId = Guid.Parse("A5E40484-167C-4CFC-B663-C3290F2A91BF");
            var inProgressStatusId = Guid.Parse("AD0F4B01-9875-4FE0-8FB8-2819858F5140");

            var request = _context.Requests.FirstOrDefault(r => r.Id == requestId);
            if (request == null) return RedirectToAction("Index");

            if (statusId == acceptedStatusId) {
                using var conn = new SqlConnection(_context.Database.GetConnectionString());
                conn.Open();

                var query = @"
                    SELECT TOP 1 Id, DriverId FROM Cars
                    WHERE SeatsCount >= @SeatsCount
                      AND Id NOT IN (
                        SELECT CarId FROM Rides
                        WHERE RideStatusId IN (@InProgressStatusId, @PlanningStatusId)
                    )";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SeatsCount", request.PassengersCount);
                cmd.Parameters.AddWithValue("@InProgressStatusId", inProgressStatusId);
                cmd.Parameters.AddWithValue("@PlanningStatusId", planningStatusId);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) {
                    TempData["Error"] = "Усі машини зайняті. Неможливо прийняти заявку.";
                    return RedirectToAction("Index");
                }

                var carId = reader.GetGuid(0);
                var driverId = reader.GetGuid(1);
                reader.Close();

                var rideId = Guid.NewGuid();
                var insert = @"
                    INSERT INTO Rides (Id, RequestId, DriverId, CarId, DepartureTime, ArrivalTime, RideStatusId, IsCompleted, CreatedOn, ModifiedOn)
                    VALUES (@Id, @RequestId, @DriverId, @CarId, @DepTime, @ArrTime, @RideStatusId, 0, GETDATE(), GETDATE())";

                using var insertCmd = new SqlCommand(insert, conn);
                insertCmd.Parameters.AddWithValue("@Id", rideId);
                insertCmd.Parameters.AddWithValue("@RequestId", request.Id);
                insertCmd.Parameters.AddWithValue("@DriverId", driverId);
                insertCmd.Parameters.AddWithValue("@CarId", carId);
                insertCmd.Parameters.AddWithValue("@DepTime", request.CreatedOn.AddHours(16));
                insertCmd.Parameters.AddWithValue("@ArrTime", request.CreatedOn.AddHours(8));
                insertCmd.Parameters.AddWithValue("@RideStatusId", planningStatusId);

                insertCmd.ExecuteNonQuery();
            }

            // Статус оновлюється тільки якщо немає помилок
            request.RequestStatusId = statusId;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
