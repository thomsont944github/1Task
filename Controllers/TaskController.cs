using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
using Task1.Repository;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskController : ControllerBase

    {

        private readonly IUserRepo _userRepo;
        public TaskController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        /*[HttpGet("Login")]
        public IActionResult Login(string Username, string Password)
        {
            var A = _userRepo.Login(Username, Password);
           
            return Ok(A);
        }*/
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest User)
        {
            var A = _userRepo.Login(User);

            return Ok(A);


        }
    }
}
