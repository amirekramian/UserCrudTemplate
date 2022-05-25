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


        public async Task<UserDto> DeleteUser(int id)
        {

            var TargetUser = dbcontext.Users.FirstOrDefaultAsync(User => User.ID == id);
            dbcontext.Users.Remove(await TargetUser);
            await dbcontext.SaveChangesAsync(); 
            return new UserDto();
            
        }

        public async Task<List<UserDto>> getAllUser()
        {
            var result = await dbcontext.Users.Select(User => new UserDto
            {
                Id = User.ID,                    
                Name = User.Name,   
                FamilyName = User.FamilyName,
                UserName = User.UserName,
                BirthDate = User.BirthDate,
                NationalCode=User.nationalCode,
                Tel = User.Tel,
                FullName = User.Name+" "+User.FamilyName,

            }).ToListAsync();
            return result;  
        }

        public async Task<UserDto> GetUserByID(int Id)
        {
         var TargetUser = await dbcontext.Users.FindAsync(Id);
            var model = new UserDto
            {

                Name = TargetUser.Name,
                FamilyName = TargetUser.FamilyName,
                Tel = TargetUser.Tel,
                NationalCode = TargetUser.nationalCode,
                BirthDate = TargetUser.BirthDate,
                FullName = TargetUser.Name + " " + TargetUser.FamilyName,
                UserName = TargetUser.UserName,

            };
            return model;
        }
    }
}
