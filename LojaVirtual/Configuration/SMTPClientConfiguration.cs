using LojaVirtual.Domain.Libraries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Configuration
{
    public static class SMTPClientConfiguration
    {
        public static void ConfigureSmtpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(options =>
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = configuration.GetValue<string>("Email:ServerSMTP"),
                    Port = configuration.GetValue<int>("Email:ServerPort"),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(configuration.GetValue<string>("Email:Username"), SensibleData.GmailPassword),
                    EnableSsl = true
                };

                return smtp;
            });

            services.AddScoped<GerenciarEmail>();
        }
    }
}