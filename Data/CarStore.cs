using wt_lab6_minimalapi_leshkevich.Models;

namespace wt_lab6_minimalapi_leshkevich.Data;

public static class CarStore
{
    public static List<Car> Cars { get; } = new()
    {
        new Car
        {
            Id = 1,
            Brand = "Toyota",
            Model = "Camry",
            PricePerDay = 75.0m,
            IsAvailable = true
        },
        new Car
        {
            Id = 2,
            Brand = "BMW",
            Model = "X5",
            PricePerDay = 150.0m,
            IsAvailable = true
        },
        new Car
        {
            Id = 3,
            Brand = "Volkswagen",
            Model = "Polo",
            PricePerDay = 40.0m,
            IsAvailable = false
        },
        new Car
        {
            Id = 4,
            Brand = "Audi",
            Model = "A6",
            PricePerDay = 120.0m,
            IsAvailable = true
        },
        new Car
        {
            Id = 5,
            Brand = "Hyundai",
            Model = "Solaris",
            PricePerDay = 45.0m,
            IsAvailable = true
        }
    };
}