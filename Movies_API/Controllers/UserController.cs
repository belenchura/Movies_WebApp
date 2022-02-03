using Microsoft.AspNetCore.Mvc;
using Movies_API.Entities;
using Movies_API.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository moviesRepository)
        {
            this._userRepository = moviesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _userRepository.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int cod_user)
        {
            var data = await _userRepository.GetByIdAsync(cod_user);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(string username,string password)
        {
            var data = await _userRepository.GetUserAsync(username, password);
            if (data == null) return Ok();
            return Ok(data);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> Add(User user)
        {
            var data = await _userRepository.AddAsync(user);
            return Ok(data);
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult> Delete(int cod_user)
        {
            var data = await _userRepository.DeleteAsync(cod_user);
            return Ok(data);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update(User user)
        {
            var data = await _userRepository.UpdateAsync(user);
            return Ok(data);
        }
    }
}
