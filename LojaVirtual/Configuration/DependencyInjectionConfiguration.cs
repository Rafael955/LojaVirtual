using LojaVirtual.Domain.Configs;
using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Infrastructure.Data.Context;
using LojaVirtual.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LojaVirtualContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<Configuracoes>(configuration.GetSection("ConfiguracoesGerais"));

            services.AddHttpContextAccessor();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INewsletterEmailRepository, NewsletterEmailRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();

            services.AddScoped<Sessao>();
            services.AddScoped<LoginCliente>();
            services.AddScoped<LoginColaborador>();
        }
    }
}