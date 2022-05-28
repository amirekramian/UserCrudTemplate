using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastrudture.Dto;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById(int ID)
        {
            var result = await userService.GetUserByID(ID); 
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await userService.getAllUser();
            return Ok(result);  
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto Model)
        {
            var result = await userService.AddUser(Model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int ID)
        {
            var result = await userService.DeleteUser(ID);
            return Ok(result);
        }
    }
}
