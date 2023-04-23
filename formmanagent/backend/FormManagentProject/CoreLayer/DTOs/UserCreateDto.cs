using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class UserCreateDto
    {
        public string  FirstName { get; set; }
        public string  UserName { get; set; }
        public string  LastName { get; set; }
        public int  Age { get; set; }
        public string  Password { get; set; }
        public string  Email { get; set; }
    }
}
