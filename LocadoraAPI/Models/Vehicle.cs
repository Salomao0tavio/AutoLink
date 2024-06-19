using Enums;
using Models;
using Models.CreateModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Vehicle
{
    [Key]
    public string Plate { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Year { get; set; }
    public bool InMaintenance { get; set; }
    public List<Rental>? Rentals { get; set; } = new List<Rental>();
    public bool Availability { get; set; }
    public VehicleCategory Category { get; set; }

    public Vehicle() { }

    [JsonConstructor]
    public Vehicle(string plate, string model, string brand, int year, VehicleCategory category, bool inMaintenance)
    {
        Plate = plate;
        Model = model;
        Brand = brand;
        Year = year;
        Category = category;
        InMaintenance = inMaintenance;
    }

    public void Update(string plate, string model, string brand, int year)
    {
        Plate = plate;
        Model = model;
        Brand = brand;
        Year = year;
    }

    internal static Vehicle Parse(VehicleCreateModel vehicle)
    {
        Vehicle _vehicle = new Vehicle
        {
            Brand = vehicle.Brand,
            Year = vehicle.Year,
            Category = vehicle.Category,
            Model = vehicle.Model,
            Plate = vehicle.Plate,
        };

        return _vehicle;

    }
}
