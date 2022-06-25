using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTest
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {

        }
        public void seed(UserCrudTemplateEntity context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Users.AddRange(

                new User()
                {
                    Name = "AddTest",
                    FamilyName = "Testing",
                    nationalCode = "1111111111",
                    UserName = "Testing",
                    BirthDate = "5/5/1400",
                    Tel = "123321"
                },
                new User()
                {
                    Name = "AddTest2",
                    FamilyName = "Testing2",
                    nationalCode = "2222222222",
                    UserName = "Testing2",
                    BirthDate = "6/6/1400",
                    Tel = "12344321"
                },
                new User()
                {
                    Name = "AddTest3",
                    FamilyName = "Testing3",
                    nationalCode = "3333333333",
                    UserName = "Testing3",
                    BirthDate = "7/7/1400",
                    Tel = "123456"
                }
                );
            context.SaveChanges();
        }
    }
}
