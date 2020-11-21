using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvioEmail.Services
{
    public class MailService
    {
        private readonly string from = "email";
        private readonly string password = "password";

        public void SendMessage(string to, string subject, string bodyText)
        {
            try
            {
                MimeMessage message = new MimeMessage();

                message.From.Add(new MailboxAddress(from)); //adiciona quem está enviando
                message.To.Add(new MailboxAddress(to)); //adiciona o destinatário
                message.Subject = subject; //Título do e-mail

                message.Body = new TextPart("plain") //textpart?? 
                {
                    Text = bodyText
                };


                using (var client = new SmtpClient()) //abrindo o client SMTP
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true; //sem validação

                    client.Connect("smtp.gmail.com", 587); //Portas comumente usadas no SMTP => 2525, 25, 587
                                                           //host outlook => smtp-mail.outlook.com

                    client.Authenticate(from, password);

                    client.Send(message);

                    Console.WriteLine($"E-mail enviado para {to} com sucesso!");

                    client.Disconnect(true);
                }
            }
            catch (Exception ex) { }
        }
    }
        
    
}
