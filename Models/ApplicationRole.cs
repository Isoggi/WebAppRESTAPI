﻿using Microsoft.AspNetCore.Identity;

namespace WebAppRESTAPI.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : this()
        {
            Name = roleName;
        }
    }
}
