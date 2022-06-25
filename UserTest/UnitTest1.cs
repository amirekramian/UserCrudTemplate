using Api.Controllers;
using Application.Interfaces;
using Application.Service;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UserTest
{
    public class UnitTest1
    {
        private readonly IUserService userService;
        [Fact]
        public async void Task_GetUserByID_Return_OkResult()
        {
            //Arrage
            var controller = new UserController(userService);
            var UserID = 1;

            //Act
            var data = await controller.GetById(UserID);

            //assert
            Assert.IsType<OkObjectResult>(data);
           
        }

        [Fact]
        public async void Task_GetPosts_Return_OkResult()
        {
            //Arrange  
            var controller = new UserController(userService);

            //Act  
            var data = await controller.GetAllUser();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }


    }
}