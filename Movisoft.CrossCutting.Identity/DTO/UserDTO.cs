using Movisoft.CrossCutting.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.CrossCutting.Identity.DTO
{
    public class UserDTO: ApplicationUser
    {
        public string Password { get; set; }
        public string ClaimValue { get; set; }
        public bool Locked { get; set; }
    }
}
