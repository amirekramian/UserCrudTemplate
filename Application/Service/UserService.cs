using Core;
using Infrastrudture.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : Interfaces.IUserService
    {

        private readonly UserCrudTemplateEntity dbcontext;

        public UserService(UserCrudTemplateEntity dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public UserDto DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> getAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
