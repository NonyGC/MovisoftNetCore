using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movisoft.CrossCutting.Identity.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<MenuRole> MenuRoles { get; set; }
    }
}
