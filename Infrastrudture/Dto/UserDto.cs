using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrudture.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string? FullName { get; set; }
        public string Tel { get; set; }
        public string BirthDate { get; set; }
        public string NationalCode { get; set; }
    }
}
