using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.Model;

namespace WebApi.Repository
{
    public interface ICityRepository
    {
         Task<List<CityModel>> GetAllCitiesAsync();
         Task<CityModel> GetCityByIdAsync(int id);
         Task<int> AddCityAsync(CityModel cityModel);
         Task DeleteCityAsync(int id);
         Task UpdateCityAsync(CityModel cityModel, int id);
         Task UpdateCityPatchAsync(JsonPatchDocument jsonPatchDocument, int id);
    }
}