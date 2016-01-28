using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DomainEvents.Handler.EmailModel
{
    public class EmailSettings
    {        
        public string MailToAddress;
      
        public string MailFromAddress = "QuadroSoftware@test.pl";
     
        public bool UseSsl = true;

        public string Username = "UżytkownikSmtp";

        public string Password = "HasłoSmtp";

        public string ServerName = "smtp.przykład.pl";

        public int ServerPort = 587;

        public bool WriteAsFile = true;

        public string FileLocation = @"C:\Hobby_emails";
    }
}
