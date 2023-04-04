namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Model;
    using WebApi.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeRepository _fuelRepository;
        private readonly IMapper _mapper;
        public FuelTypeController(IFuelTypeRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllFuelType()
        {
            var types = await _fuelRepository.GetAllFuelTypesAsync();
            var result = _mapper.Map<List<FuelTypeModel>>(types);
            return Ok(result);
        }
    }
}