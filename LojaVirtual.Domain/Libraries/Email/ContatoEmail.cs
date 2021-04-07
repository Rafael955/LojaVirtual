using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Resources;
using LojaVirtual.Domain.Models;
using LojaVirtual.Domain.Libraries.SensibleData;

namespace LojaVirtual.Domain.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("rafaelcaffonso@gmail.com", SensibleData.SensibleData.GmailPassword);
            smtp.EnableSsl = true;

            /*
             * MailMessage -> Construir a mensagem
             */

            string corpoMsg = $"<h2>Contato - LojaVirtual</h2>" +
                $"<b>Nome: </b> {contato.Nome} <br/>" +
                $"<b>E-mail: </b> {contato.Email} <br/>" +
                $"<b>Texto: </b> {contato.Texto} <br/>" +
                $"<br/>E-mail enviado automaticamente do site LojaVirtual";

            MailMessage mensagem = new MailMessage()
            {
                From = new MailAddress("rafaelcaffonso@gmail.com"),
                Subject = "Contato - LojaVirtual - E-mail: " + contato.Email,
                Body = corpoMsg,
                IsBodyHtml = true
            };

            mensagem.To.Add("rafaelcaffonso@gmail.com");

            //Enviar mensagem via SMTP
            smtp.Send(mensagem);
        }
    }
}
