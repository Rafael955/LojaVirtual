using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Repositories
{
    public class NewsletterEmailRepository : Repository<NewsletterEmail>, INewsletterEmailRepository
    {
        public NewsletterEmailRepository(LojaVirtualContext context) : base(context)
        {

        }

        public async Task Add(NewsletterEmail newsletter)
        {
            await _context.AddAsync(newsletter);
            await _context.SaveChangesAsync();
        }
    }
}
