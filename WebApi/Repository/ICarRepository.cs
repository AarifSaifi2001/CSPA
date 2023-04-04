using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Repository
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarListAsync(int sellRent);

        Task<Car> GetCarByIdAsync(int id);
        Task<List<Car>> GetCarsByUserIdAsync(int userId);

        Task<Car> CarByIdAsync(int id);
        Task<string> AddCarAsync(Car car);

        void DeleteCarAsync(int id);
    }
}