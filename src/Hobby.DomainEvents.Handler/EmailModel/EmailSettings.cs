using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DomainEvents.Handler.EmailModel
{
    public class EmailSettings
    {
        public string MailToAddress { get; set; }

        public string MailFromAddress 
        {
            get { return "QuadroSoftware@test.pl"; } 
        }

        public bool UseSsl 
        { 
            get { return true; } 
        }

        public string Username 
        { 
            get { return "UżytkownikSmtp"; } 
        }

        public string Password 
        { 
            get { return "HasłoSmtp"; } 
        }

        public string ServerName 
        {
            get { return "smtp.przykład.pl"; } 
        }

        public int ServerPort 
        {
            get { return 587; } 
        }

        public bool WriteAsFile 
        { 
            get { return true; } 
        }

        public string FileLocation 
        { 
            get { return @"C:\Hobby_emails"; } 
        }
    }
}
