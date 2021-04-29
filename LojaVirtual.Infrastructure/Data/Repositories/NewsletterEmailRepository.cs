using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class NewsletterEmailRepository : Repository<NewsletterEmail>, INewsletterEmailRepository
    {
        public NewsletterEmailRepository(LojaVirtualContext context) : base(context)
        {
        }
    }
}