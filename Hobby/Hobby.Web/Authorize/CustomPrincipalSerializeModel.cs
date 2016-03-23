using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hobby.Web.Authorize
{
    public class CustomPrincipalSerializeModel
    {
        public decimal UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<string> roles { get; set; }
    }
}