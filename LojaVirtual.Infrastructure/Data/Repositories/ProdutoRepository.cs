using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto, int>, IProdutoRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public ProdutoRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public override async Task<IPagedList<Produto>> ObterTodosPaginado(int? pagina, string pesquisa)
        {
            int NumeroDaPagina = pagina ?? 1;

            if (pesquisa != null)
            {
                pesquisa = pesquisa.Trim();
                return await _lojaContext.Produtos.Where(x => x.Nome.Contains(pesquisa.Trim())).ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
            }

            return await _lojaContext.Produtos.ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }
    }
}