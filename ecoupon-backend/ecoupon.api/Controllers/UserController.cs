using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ecoupon.DTO;
using ecoupon.models;
using ecoupon.repository.contracts;
using Microsoft.AspNetCore.Mvc;
using ecoupon.api.Hub;
using Microsoft.AspNetCore.SignalR;

namespace ecoupon.api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public UserController(IUserRepository repo, IMapper mapper, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._mapper = mapper;
            this._hubContext = hubContext;
            this._repo = repo;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> Get()
        {

            var users = await _repo.GetAllUsers();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok(userDto);
        }
    }
}