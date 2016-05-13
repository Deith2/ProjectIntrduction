using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hobby.Web.Parts.UserSettings.Models
{
    public class SettingsModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}