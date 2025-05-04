using AutoBase.Domain;
using AutoBase.Domain.Entities;
using AutoBaseSystem.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class RideController : BaseController {
    private readonly string _connectionString;

    public RideController(IConfiguration configuration) {
        _connectionString = configuration.GetConnectionString("Default");
    }

    public IActionResult Index() {
        var rides = new List<Ride>();

        using (var connection = new SqlConnection(_connectionString)) {
            var command = new SqlCommand(@"
                SELECT r.Id, r.ArrivalTime, r.DepartureTime, r.IsCompleted,
                       c.Id AS CarId, c.Model, c.PlateNumber,
                       s.Id AS RideStatusId, s.Name AS StatusName
                FROM Rides r
                JOIN Cars c ON r.CarId = c.Id
                JOIN RideStatuses s ON r.RideStatusId = s.Id", connection);

            connection.Open();
            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    var ride = new Ride {
                        Id = reader.GetGuid(reader.GetOrdinal("Id")),
                        ArrivalTime = reader.GetDateTime(reader.GetOrdinal("ArrivalTime")),
                        DepartureTime = reader.GetDateTime(reader.GetOrdinal("DepartureTime")),
                        IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted")),
                        Car = new Car {
                            Id = reader.GetGuid(reader.GetOrdinal("CarId")),
                            Model = reader.GetString(reader.GetOrdinal("Model")),
                            PlateNumber = reader.GetString(reader.GetOrdinal("PlateNumber"))
                        },
                        RideStatus = new RideStatus {
                            Id = reader.GetGuid(reader.GetOrdinal("RideStatusId")),
                            Name = reader.GetString(reader.GetOrdinal("StatusName"))
                        }
                    };
                    rides.Add(ride);
                }
            }
        }

        return View(rides);
    }
}
