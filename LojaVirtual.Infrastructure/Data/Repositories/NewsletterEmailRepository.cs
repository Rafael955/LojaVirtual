using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
using System;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class NewsletterEmailRepository : Repository<NewsletterEmail, Guid>, INewsletterEmailRepository
    {
        public NewsletterEmailRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}