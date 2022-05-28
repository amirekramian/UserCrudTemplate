﻿using Core;
using Infrastrudture.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<UserDto> AddUser(UserDto model)
        {
            var User = new Core.User
            {
                Name = model.Name,
                FamilyName = model.FamilyName,
                UserName = model.UserName,
                Tel = model.Tel,
                nationalCode = model.NationalCode,
                BirthDate = model.BirthDate,
            };
            dbcontext.Users.AddAsync(User);
            dbcontext.SaveChangesAsync();

            model.Id = User.ID;
            return model;
        }

        public async Task<UserDto> DeleteUser(int id)
        {

            var TargetUser = dbcontext.Users.FindAsync(id);
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
           var user = await dbcontext.Users.FindAsync(Id);
            var model = new UserDto
            {
                Id = user.ID,
                Name = user.Name,
                FamilyName = user.FamilyName,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                NationalCode = user.nationalCode,
                Tel = user.Tel,
                FullName = user.Name + " " + user.FamilyName,
            };
            return model;
            
        }

        public async Task<UserDto> UpdateUser(int ID)
        {
            var targetUser = await dbcontext.Users.FindAsync(ID);
            var Model = new UserDto
            {
                Name = targetUser.Name,
                FamilyName = targetUser.FamilyName,
                Tel = targetUser.Tel,
                NationalCode = targetUser.nationalCode,
                BirthDate = targetUser.BirthDate,
                FullName = targetUser.Name + " " + targetUser.FamilyName,
                UserName = targetUser.UserName,
            };
            dbcontext.Users.Update(targetUser);
            dbcontext.SaveChanges();
            Model.Id = targetUser.ID;
            return Model;
        }
    }
}
