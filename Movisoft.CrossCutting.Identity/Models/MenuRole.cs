using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movisoft.CrossCutting.Identity.Models
{
    public class MenuRole
    {
        public Menu Menu { get; set; }
        public int MenuId { get; set; }

        public  ApplicationRole Role { get; set; }
        public int RoleId { get; set; }
    }
}
