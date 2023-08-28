using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using interrapidisimo.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interrapidisimo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserRepository _repository;

        public UserController(IApplicationUserRepository applicationUserRepository){
            _repository = applicationUserRepository;
        }

        [HttpGet("get-userid")]
        public async Task<IActionResult> Get(string userName)
        {
            var user = await _repository.GetUserId(userName);
            return Ok(new {userId = user});
        }
    }
}