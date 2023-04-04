using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Repository
{
    public interface IFuelTypeRepository
    {
        Task<List<FuelType>> GetAllFuelTypesAsync();
    }
}