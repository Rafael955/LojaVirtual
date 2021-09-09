using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria, int>, ICategoriaRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public CategoriaRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public override async Task<IPagedList<Categoria>> ObterTodosPaginado(int? pagina, string pesquisa)
        {
            var NumeroDaPagina = pagina ?? 1;
            return await _lojaContext.Categorias.Include(x => x.CategoriaPai).ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }
    }
}