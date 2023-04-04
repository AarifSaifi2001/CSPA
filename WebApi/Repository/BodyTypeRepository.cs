using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repository
{
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private readonly CityContext _context;
        public BodyTypeRepository(CityContext context)
        {
            _context = context;
        }
        public async Task<List<BodyType>> GetAllBodyTypesAsync()
        {
            var types = await _context.BodyTypes.ToListAsync();
            return types;
        }
    }
}