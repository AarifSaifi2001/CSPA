using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly CityContext _context;
        public FuelTypeRepository(CityContext context)
        {
            _context = context;
        }
        public async Task<List<FuelType>> GetAllFuelTypesAsync()
        {
            var types = await _context.FuelTypes.ToListAsync();
            return types;
        }
    }
}