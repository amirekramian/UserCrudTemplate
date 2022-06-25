using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Infrastrudture.Dto;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet("{ID}")]

        [SwaggerOperation(
            Summary = "Get a User",
            Description = "Get a User with ID",
            OperationId = "User.GetById")]


        public async Task<IActionResult> GetById(int ID)
        {
            var result = await userService.GetUserByID(ID);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all Users",
            Description = "Get every user created",
            OperationId = "User.Get")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await userService.getAllUser();
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Add a User",
            Description = "Add a User in Database",
            OperationId = "User.Add")]
        public async Task<IActionResult> AddUser(UserDto Model)
        {
            var result = await userService.AddUser(Model);
            return Ok(result);
        }

        [HttpDelete("{ID}")]
        [SwaggerOperation(
            Summary = "remove a User",
            Description = "remove a user by ID",
            OperationId = "User.remove")]
        public async Task<IActionResult> RemoveUser(int ID)
        {
            var result = await userService.DeleteUser(ID);
            return Ok(result);
        }
        [HttpPut]
        [SwaggerOperation(
            Summary = "Update User",
            Description = "Update a User with ID",
            OperationId = "User.Update")]
        public async Task<IActionResult> UpdatUser(UserDto Model)
        {
            var result = await userService.UpdateUser(Model);
            return Ok(result);
        }
    }
}
