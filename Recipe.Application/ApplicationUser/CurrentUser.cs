﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.ApplicationUser
{
    public class CurrentUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public CurrentUser(string id, string email )
        {
            Email = email;
            Id = id;
        }
    }
}
