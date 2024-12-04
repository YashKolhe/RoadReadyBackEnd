using RoadReady.Data;
using RoadReady.Models;

namespace RoadReady.Repositories
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {
            try
            {
                return _context.Cars.ToList();
            }
            catch (Exception ex) 
            {
                throw;
            }
            
        }

        public Car GetCarById(int id)
        {
            try
            {
                return _context.Cars.Find(id);
            }catch (Exception ex)
            {
                throw;
            }
        }

        public int AddCar(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return car.CarId;
            }catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateCar(Car car)
        {
            try
            {
                var existingCar = _context.Cars.Find(car.CarId);
                if (existingCar == null) return "Car not found";

                existingCar.Make = car.Make;
                existingCar.Model = car.Model;
                existingCar.Year = car.Year;
                existingCar.Color = car.Color;
                existingCar.PricePerDay = car.PricePerDay;
                existingCar.AvailabilityStatus = car.AvailabilityStatus;
                existingCar.Description = car.Description;

                _context.SaveChanges();
                return "Car updated successfully";
            }catch(Exception ex)
            { 
                throw;
            }
        }

        public string DeleteCar(int id)
        {
            try
            {
                var existingCar = _context.Cars.Find(id);
                if (existingCar == null) return "Car not found";

                _context.Cars.Remove(existingCar);
                _context.SaveChanges();
                return "Car deleted successfully";
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
