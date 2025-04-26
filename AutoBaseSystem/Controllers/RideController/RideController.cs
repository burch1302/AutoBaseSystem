using AutoBase.Domain;
using AutoBaseSystem.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class RideController : BaseController {
    private readonly AutoBaseSystemContext _context;

    public RideController(AutoBaseSystemContext context) {
        _context = context;
    }

    public IActionResult Index() {
        var rides = _context.Rides
            .Include(r => r.Car)
            .Include(r => r.RideStatus)
            .ToList();

        return View(rides);
    }
}
