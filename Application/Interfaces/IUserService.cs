using Infrastrudture.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> getAllUser();
        Task<UserDto> GetUserByID(int Id);
        Task<UserDto> DeleteUser(int id);
        Task<UserDto> AddUser(UserDto user);
    }
}
