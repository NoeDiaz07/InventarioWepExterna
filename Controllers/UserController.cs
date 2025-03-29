using InventarioWepExterna.DTO;
using InventarioWepExterna.Models;
using InventarioWepExterna.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace InventarioWepExterna.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        public UsersController(ApplicationDbcontext context)
        {
            _context = context;
        }
        private static List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Career = "Engineering", Age = 20, Enrollment = "202001" },
            new User { Id = 2, Name = "Bob Brown", Email = "bob@example.com", Career = "Law", Age = 22, Enrollment = "202002" }
        };

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers() => Ok(Users);

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task <IActionResult> CreateUser(CreateUserDTO newUser)
        {
            var user = new User
            {
                Name = newUser.name,
                Email = newUser.email,
                Age = newUser.age,
                Career= newUser.Career,
                Enrollment= newUser.Enrollment
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Career = updatedUser.Career;
            user.Age = updatedUser.Age;
            user.Enrollment = updatedUser.Enrollment;

            return NoContent();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            Users.Remove(user);
            return NoContent();
        }
    }
}