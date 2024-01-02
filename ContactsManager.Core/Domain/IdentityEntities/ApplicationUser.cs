﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Core.Domain.IdentityEntities
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public Guid UserId { get; set;}

        public string Role { get; set; }
    }
}
