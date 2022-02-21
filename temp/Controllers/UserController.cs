using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Service.SysService;

namespace temp.Controllers
{
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUserList")]
        public async Task<IList<User>> GetUserList()
        {
            return await _userService.GetUserList();
        }
    }
}