using AutoMapper;
using CarDealerApi.Dto;
using CarDealerApi.Interface;
using CarDealerApi.Models;
using CarDealerApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CarDealerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userInterface;
        private readonly IMapper _mapper;
        public UserController(UserInterface userInterface, IMapper mapper)
        {
            _userInterface = userInterface;
            _mapper = mapper;
        }
        [HttpGet("Cars/{userid}")]
        [ProducesResponseType(200,Type=typeof(List<Car>))]
        public IActionResult GetCarByUser(int userid)
        {
            var cars= _userInterface.GetCarByUser(userid);
            if(cars == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            var cardto=_mapper.Map<List<CarDto>>(cars);
            return Ok(cardto);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userInterface.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }

        [HttpGet("username/{Username}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserByName(string Username)
        {
            if (!_userInterface.UserExitsByUser(Username))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userInterface.GetUserByName(Username));

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserById(int id)
        {
            if (!_userInterface.UserExitsById(id))
                return NotFound();
            var user = _mapper.Map<UserDto>(_userInterface.GetUserById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            byte[] salt = GenerateSalt();

            byte[] encryptedPassword = EncryptPassword(userDto.Password, salt);

            var user = new User
            {
                Username = userDto.Username,
                Password = encryptedPassword,
                Email = userDto.Email,
                salt = salt
            };

            bool success = _userInterface.CreateUser(user);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private byte[] EncryptPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32);
                return hash;
            }
        }

        [HttpPut("{UserId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int UserId, [FromBody] UserDto updateUser)
        {
            if (updateUser == null)
                return BadRequest("Invalid payload");

            if (UserId != updateUser.Id)
                return BadRequest("User ID mismatch");

            if (!_userInterface.UserExitsById(UserId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            byte[] salt = GenerateSalt();

            byte[] encryptedPassword = EncryptPassword(updateUser.Password, salt);

            var userMap = _mapper.Map<User>(updateUser);
            userMap.Password = encryptedPassword;
            userMap.salt = salt;

            if (!_userInterface.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int Id)
        {
            if (!_userInterface.UserExitsById(Id))
            {
                return NotFound();
            }

            var userToDelete = _userInterface.GetUserById(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userInterface.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LogDto userLoginDto)
        {
            User user = _userInterface.GetUserByName(userLoginDto.Username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            bool isValidPassword = _userInterface.ValidateUserPassword(user, userLoginDto.Password);

            if (!isValidPassword)
            {
                return BadRequest("Invalid password");
            }

            return Ok(user);
        }
    }
}
