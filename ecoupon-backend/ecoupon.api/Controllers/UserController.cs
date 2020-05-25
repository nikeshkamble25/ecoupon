using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ecoupon.DTO;
using ecoupon.models;
using ecoupon.repository.contracts;
using Microsoft.AspNetCore.Mvc;

namespace ecoupon.api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {
            
            var users = await _repo.GetAllUsers();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDto);
        }
    }
}