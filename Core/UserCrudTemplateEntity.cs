using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UserCrudTemplateEntity : DbContext
    {
        public UserCrudTemplateEntity(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
    }
}
