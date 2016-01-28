using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.DomainEvents.Handler.EmailModel
{
    public class EmailOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrderNewUser(decimal UserId, string email)
        {
            //Konfiguracja SMTP
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                          emailSettings.Password);
                //Sprawdzenie folderu
                if (!System.IO.File.Exists(emailSettings.FileLocation))
                {
                    System.IO.Directory.CreateDirectory(emailSettings.FileLocation);
                }
                //Zapis do pliku
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                //Wybranie konkretnego użytkownika 
     

                //Treść emaila
                StringBuilder body = new StringBuilder()
                .AppendLine("Mail został wygenerowany")
                .AppendLine("\nDane użytkownika")
                .AppendLine("Login: " + "darek4")
                .AppendLine("Hasło: " + "test")
                .AppendLine("Imię: " + "DAREK")
                .AppendLine("Nazwisko: " + "Lukasik")
                .AppendLine("Email: " + "czarnuch100@gmail.com")
                .AppendLine("Telefon: " + "605321863")
                .AppendLine("\n")
                .AppendLine("W razie prolemów proszę o kontakt z administratorem.")
                .AppendLine("\nPamiętaj aby usunąć tego maila.")

                .AppendLine("\n---")
                .AppendLine("Pozdrawiamy,")
                .AppendLine("QuadroSoftware");


                //Dane nadawcy  
                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress = "czarnuch100@gmail.com",
                    "Witamy w programie Qnet: " + "DAREK4" + " " + "lUKASIK",
                    body.ToString());
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
