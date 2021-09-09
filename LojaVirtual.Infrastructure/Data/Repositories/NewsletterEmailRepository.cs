using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class NewsletterEmailRepository : Repository<NewsletterEmail, Guid>, INewsletterEmailRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public NewsletterEmailRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public override async Task<IPagedList<NewsletterEmail>> ObterTodosPaginado(int? pagina, string pesquisa)
        {
            var NumeroDaPagina = pagina ?? 1;
            return await _lojaContext.NewsletterEmails.ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }
    }
}