using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CityContext _context;
        
        public CarRepository(CityContext context)
        {
            _context = context;
        }
        public async Task<string> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return "created";
        }

        public void DeleteCarAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var car = await _context.Cars
            .Include(c => c.FuelType)
            .Include(c => c.BodyType)
            .Include(c => c.City)
            .Include(c => c.Photos)
            .Include(c => c.User)
            .Where(c => c.id == id)
            .FirstOrDefaultAsync();
            return car; 
        }

        public async Task<Car> CarByIdAsync(int id)
        {
            var car = await _context.Cars
            .Include(c => c.Photos)
            .Where(c => c.id == id)
            .FirstOrDefaultAsync();
            return car;
        }

        public async Task<List<Car>> GetCarListAsync(int sellRent)
        {
            var cars = await _context.Cars
            .Include(c => c.FuelType)
            .Include(c => c.BodyType)
            .Include(c => c.City)
            .Include(c => c.Photos)
            .Where(c => c.SellRent == sellRent)
            .ToListAsync();
            return cars;
        }

        public async Task<List<Car>> GetCarsByUserIdAsync(int userId){

            var cars = await _context.Cars
            .Include(c => c.FuelType)
            .Include(c => c.BodyType)
            .Include(c => c.City)
            .Include(c => c.Photos)
            .Where(c => c.PostedBy == userId)
            .ToListAsync();
            return cars;
        }
    }
}