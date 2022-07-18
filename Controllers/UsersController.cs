using KMStore.API.Models;
using KMStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KMStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            var userWithExistingEmail = await _userRepository.CheckUserWithSameEmail(user.Email);

            if (userWithExistingEmail != null)
            {
                return BadRequest("User with the same email already exist");
            }
            else
            {
                await _userRepository.Register(user);
                return StatusCode(StatusCodes.Status201Created, "User Successfully Added");
            }
        }
    }
}
