using Hobby.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Hobby.Web.Authorize
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly IUserService _userService;

        public CustomPrincipal(IUserService userService) 
        {
            _userService = userService;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string username)
        {
            this.Identity = new GenericIdentity(username);
        }

        public decimal UserId { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public List<string> roles { get; set; }
    }
}