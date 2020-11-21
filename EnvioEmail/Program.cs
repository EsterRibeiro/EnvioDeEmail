using EnvioEmail.Services;
using System;
using System.Net.Mail;

namespace EnvioEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            MailService mailService = new MailService();

            mailService.SendMessage("email", "Primeiro Envio de Email", "Teste");
           
        }

       
    }
}
