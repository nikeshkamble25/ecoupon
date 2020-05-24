using Microsoft.AspNetCore.Mvc;

namespace ecoupon.api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("getuser")]
        public string Get()
        {
            return "Nikesh";
        }
    }
}