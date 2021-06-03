using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using System;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class NewsletterEmailRepository : Repository<NewsletterEmail, Guid>, INewsletterEmailRepository
    {
        public NewsletterEmailRepository(LojaVirtualContext context) : base(context)
        {
        }
    }
}