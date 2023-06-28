using CarDealerApi.Data;
using CarDealerApi.Interface;
using CarDealerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealerApi.Repository
{
    public class CarRepository : CarInterface
    {
        private readonly AppDBContext _context;
        public CarRepository(AppDBContext context) => _context = context;

        public bool CarExitsById(int id)
        {
            return _context.cars.Any(u => u.Id == id);
        }

        public bool CarExitsByName(string name)
        {
            return _context.cars.Any(u => u.Mark== name);
        }

        public bool CreateCar(Car car)
        {
            _context.Add(car);
            return Save();
        }

        public bool DeleteCar(Car car)
        {
            _context.Remove(car);
            return Save();
        }

        public Car GetCarId(int id)
        {
            return _context.cars.Where(u => u.Id == id).FirstOrDefault() ?? null;
        }

        public Car GetCarName(string name)
        {
            return _context.cars.Where(u => u.Mark == name).FirstOrDefault() ?? null;
        }

        public ICollection<Car> GetCars()
        {
            return _context.cars.OrderBy(u => u.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCar(Car car)
        {
            _context.Update(car);
            return Save();
        }
    }
}
