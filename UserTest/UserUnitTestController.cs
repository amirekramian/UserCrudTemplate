using Application.Interfaces;
using Application.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTest
{
    public class UserUnitTestController
    {
        private UserService repository;
        public static DbContextOptions<UserCrudTemplateEntity> dbContextOptions { get; }
        public static string connectionString = "Server=192.168.1.103;Database=UserTestDB;UID=sa;PWD=MYsqlserver1378;";

        static UserUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<UserCrudTemplateEntity>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public UserUnitTestController()
        {
            var context = new UserCrudTemplateEntity(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.seed(context);
            repository = new UserService(context);
        }
    }
}
