﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hobby.Web.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
