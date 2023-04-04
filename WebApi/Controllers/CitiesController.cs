namespace WepApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Model;
    using WebApi.Repository;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCities(){
            var records = await _cityRepository.GetAllCitiesAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById([FromRoute]int id){
            var record = await _cityRepository.GetCityByIdAsync(id);
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody]CityModel cityModel){
            var result = await _cityRepository.AddCityAsync(cityModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity([FromRoute]int id){
            await _cityRepository.DeleteCityAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity([FromBody]CityModel cityModel, [FromRoute]int id){
            await _cityRepository.UpdateCityAsync(cityModel, id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCityPatch([FromBody]JsonPatchDocument jsonPatchDocument, [FromRoute]int id){
            await _cityRepository.UpdateCityPatchAsync(jsonPatchDocument, id);
            return Ok();
        }
    }
}