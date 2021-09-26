using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente, Guid>, IClienteRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public ClienteRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async Task<Cliente> Login(string email, string senha)
        {
            return await _lojaContext.Clientes.Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();
        }

        public override async Task<IPagedList<Cliente>> ObterTodosPaginado(int? pagina, string pesquisa)
        {
            int NumeroDaPagina = pagina ?? 1;

            if (pesquisa != null)
            {
                pesquisa = pesquisa.Trim();
                return await _lojaContext.Clientes.Where(x => x.Nome.Contains(pesquisa.Trim()) || x.Email.Contains(pesquisa.Trim())).ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
            }

            return await _lojaContext.Clientes.ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }
    }
}