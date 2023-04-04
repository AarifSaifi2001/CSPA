namespace WebApi.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using WebApi.Data;
    using WebApi.Model;
    using WebApi.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly CityContext _context;
        public AccountController(IUserRepository userRepository, IConfiguration configuration, IMapper mapper, CityContext context)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(UserModel userModel)
        {
            var user = await _userRepository.Authenticate(userModel.username, userModel.password);
            
            if(user == null){
                return Unauthorized("Username or Password is Invalid");
            }

            var res = new UserResModel();
            res.username = user.username;
            res.token = CreateJWT(user);
            res.id = user.id;
            

            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel userModel){

            if(await _userRepository.UserAlreadyExists(userModel.username)){
                return BadRequest("User is Already Exists in the Database Please Provide other Username");
            }

             _userRepository.Register(userModel.username, userModel.password, userModel.email, userModel.mobileno);
             return StatusCode(201);
        }

        private string CreateJWT(User user){

            var SecretKey = _configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
            };

            var signingCredentails = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentails
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet("userinfo/{userId}")]
        public async Task<IActionResult> UserInfo(int userId){
            var user = await _userRepository.UserInfoAsync(userId);
            var userInfo = _mapper.Map<UserModel2>(user);
            return Ok(userInfo);
        }

        [HttpPut("updatepassword/{userId}")]
        public async Task<IActionResult> UserUpdatePassword(int userId, UserPasswordUpdateModel userModel){

            await _userRepository.UserUpdatePasswordAsync(userId, userModel);
            return StatusCode(200);
        }

    }
}