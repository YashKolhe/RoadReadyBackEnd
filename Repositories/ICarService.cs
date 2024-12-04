using RoadReady.Models;

namespace RoadReady.Repositories
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        Car GetCarById(int id);
        int AddCar(Car car);
        string UpdateCar(Car car);
        string DeleteCar(int id);
    }
}
