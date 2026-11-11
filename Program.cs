using wt_lab6_minimalapi_leshkevich.Data;
using wt_lab6_minimalapi_leshkevich.Models;

var builder = WebApplication.CreateBuilder(args);

// Регистрируем генератор Swagger
builder.Services.AddEndpointsApiExplorer(); // swag
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // интерфейс
}

app.MapGet("/", () => "Minimal API работает!");

app.MapGet("/api/info", () =>
    new { Application = "Web Technologies", Technology = "ASP.NET Core Minimal API", Version = "1.0" });

app.MapGet("/api/cars", (string? search) =>
{
    var cars = CarStore.Cars.AsEnumerable();
    if (!string.IsNullOrWhiteSpace(search))
    {
        cars = cars.Where(x =>
            x.Brand.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            x.Model.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
    return Results.Ok(cars);
});

app.MapGet("/api/cars/{id}", (int id) =>
{
    var car = CarStore.Cars.FirstOrDefault(x => x.Id == id); // 1
    if (car == null) return Results.NotFound();
    return Results.Ok(car);
});

app.MapPost("/api/cars", (Car car) =>
{
    var newId = CarStore.Cars.Count == 0 ? 1 : CarStore.Cars.Max(x => x.Id) + 1;
    car.Id = newId;
    CarStore.Cars.Add(car);
    return Results.Created($"/api/cars/{car.Id}", car);
});

app.MapPut("/api/cars/{id}", (int id, Car updatedCar) =>
{
    var car = CarStore.Cars.FirstOrDefault(x => x.Id == id);
    if (car == null) return Results.NotFound();

    car.Brand = updatedCar.Brand;
    car.Model = updatedCar.Model;
    car.PricePerDay = updatedCar.PricePerDay;
    car.IsAvailable = updatedCar.IsAvailable;

    return Results.Ok(car);
});

app.MapDelete("/api/cars/{id}", (int id) =>
{
    var car = CarStore.Cars.FirstOrDefault(x => x.Id == id);
    if (car == null) return Results.NotFound();

    CarStore.Cars.Remove(car);
    return Results.NoContent();
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");