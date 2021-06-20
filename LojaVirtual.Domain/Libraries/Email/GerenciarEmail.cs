using LojaVirtual.Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace LojaVirtual.Domain.Libraries
{
    public class GerenciarEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _configuration;

        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
            var username = _configuration.GetValue<string>("Email:Username");

            string corpoMsg = $"<h2>Contato - LojaVirtual</h2>" +
                $"<b>Nome: </b> {contato.Nome} <br/>" +
                $"<b>E-mail: </b> {username} <br/>" +
                $"<b>Texto: </b> {contato.Texto} <br/>" +
                $"<br/>E-mail enviado automaticamente do site LojaVirtual";

            MailMessage mensagem = new MailMessage
            {
                From = new MailAddress(username),
                Subject = "Contato - LojaVirtual - E-mail: " + contato.Email,
                Body = corpoMsg,
                IsBodyHtml = true
            };

            mensagem.To.Add(username);

            //Enviar mensagem via SMTP
            _smtp.Send(mensagem);
        }

        public void EnviarSenhaParaColaboradorPorEmail(Colaborador colaborador)
        {
            var username = _configuration.GetValue<string>("Email:Username");

            string corpoMsg = $"<h2>Colaborador - LojaVirtual</h2>" +
                $"Sua senha é: <h3>{colaborador.Senha}</h3>";

            MailMessage mensagem = new MailMessage
            {
                From = new MailAddress(username),
                Subject = "Colaborador - LojaVirtual - Senha do colaborador: " + colaborador.Email,
                Body = corpoMsg,
                IsBodyHtml = true
            };

            mensagem.To.Add(colaborador.Email);

            //Enviar mensagem via SMTP
            _smtp.Send(mensagem);
        }
    }
}