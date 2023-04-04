namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Data;
    using WebApi.Model;
    using WebApi.Repository;
    using WebApi.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoservice;
        private readonly CityContext _context;
        public CarController(ICarRepository carRepository, IMapper mapper, IPhotoService photoService, CityContext context)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _photoservice = photoService;
            _context = context;
        }


        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCarList(int sellRent)
        {
            var cars = await _carRepository.GetCarListAsync(sellRent);
            var carModel = _mapper.Map<List<CarModel>>(cars);
            return Ok(carModel);
        }

        [HttpGet("usercars/{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCarsByUserId(int userId)
        {
            var cars = await _carRepository.GetCarsByUserIdAsync(userId);
            var carModel = _mapper.Map<List<CarModel>>(cars);
            return Ok(carModel);
        }

        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carRepository.GetCarByIdAsync(id);
            var carDetailModel = _mapper.Map<CarDetailModel>(car);
            return Ok(carDetailModel);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddCar(CarSaveModel carSaveModel)
        {
            var car = _mapper.Map<Car>(carSaveModel);
            var userId = GetUserId();
            car.PostedBy = userId;
            car.LastUpdatedBy = userId;
            await _carRepository.AddCarAsync(car);
            return StatusCode(201);
        }

        //car/add/photo/1
        [HttpPost("add/photo/{carId}")]
        [Authorize]
        public async Task<ActionResult<PhotosModel>> AddCarPhoto(IFormFile file, int carId)
        {
            var result = await _photoservice.UploadImageAsync(file);

            if(result.Error != null) 
            return BadRequest(result.Error.Message);

            var car = await _carRepository.CarByIdAsync(carId);

            var photo = new Photos
            {
                imageUrl = result.SecureUrl.AbsoluteUri,
                publicId = result.PublicId
            };

            if(car.Photos.Count == 0){
                photo.isPrimary =  true;
            } 

            car.Photos.Add(photo);
            await _context.SaveChangesAsync();
            return _mapper.Map<PhotosModel>(photo); 
            
        } 

        //set-primary-photo/1/w386siugy 
        [HttpPost("set-primary-photo/{carId}/{photoPublicId}")]
        [Authorize]
        public async Task<IActionResult> SetPrimaryPhoto(int carId, string photoPublicId)
        {
            var userId = GetUserId();

            var car = await _carRepository.GetCarByIdAsync(carId);

            if(car == null)
                return BadRequest("No such property or photo exists");

            if(car.PostedBy != userId)
                return BadRequest("You are not authorised to change the photo");

            var photo = car.Photos.FirstOrDefault(p => p.publicId == photoPublicId);

            if(photo == null)
                return BadRequest("No such property or photo exists");

            if(photo.isPrimary)
                return BadRequest("This is already a primary photo");

            var currentPrimary = car.Photos.FirstOrDefault(p => p.isPrimary);

            if(currentPrimary != null)
                currentPrimary.isPrimary = false;

            photo.isPrimary = true;

            await _context.SaveChangesAsync();

            return NoContent(); 
        }


        //delete-primary-photo/1/w386siugy 
        [HttpDelete("delete-photo/{carId}/{photoPublicId}")]
        [Authorize]
        public async Task<IActionResult> DeletePhoto(int carId, string photoPublicId)
        {
            var userId = GetUserId();

            var car = await _carRepository.GetCarByIdAsync(carId);

            if(car == null)
                return BadRequest("No such car or photo exists");

            if(car.PostedBy != userId)
                return BadRequest("You are not authorised to delete the photo");

            var photo = car.Photos.FirstOrDefault(p => p.publicId == photoPublicId);

            if(photo == null)
                return BadRequest("No such car or photo exists");

            if(photo.isPrimary)
                return BadRequest("You can not delete a primary photo");

            var result = await _photoservice.DeletePhotoAsync(photoPublicId);

            if(result.Error != null)
                return BadRequest(result.Error.Message);    

            car.Photos.Remove(photo);

            await _context.SaveChangesAsync();

            return Ok(); 
        }

        private int GetUserId(){

            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        // [HttpGet("userid")]
        // [AllowAnonymous]
        // public int UsedId(){
        //     return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        // }
    }
}