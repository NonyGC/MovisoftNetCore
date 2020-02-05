﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movisoft.CrossCutting.Identity.Models
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
