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
    public class BodyTypeController : ControllerBase
    {
        private readonly IBodyTypeRepository _bodyRepository;
        private readonly IMapper _mapper;
        public BodyTypeController(IBodyTypeRepository bodyRepository, IMapper mapper)
        {
            _bodyRepository = bodyRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllBodyType()
        {
            var types = await _bodyRepository.GetAllBodyTypesAsync();
            var result = _mapper.Map<List<BodyTypeModel>>(types);

            return Ok(result);
        }
    }
}