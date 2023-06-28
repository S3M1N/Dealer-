using CarDealerApi.Models;

namespace CarDealerApi.Interface
{
    public interface CarInterface
    {
        ICollection<Car> GetCars();
        Car GetCarId(int id);
        bool CarExitsById(int id);
        Car GetCarName(string name);
        bool CarExitsByName(string name);
        bool CreateCar(Car car);
        bool Save();
        bool UpdateCar(Car car);
        bool DeleteCar(Car car);
    }
}
