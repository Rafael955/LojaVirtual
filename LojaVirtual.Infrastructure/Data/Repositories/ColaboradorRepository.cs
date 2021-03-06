using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class ColaboradorRepository : Repository<Colaborador, Guid>, IColaboradorRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public ColaboradorRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async Task<Colaborador> Login(string email, string senha)
        {
            return await _lojaContext.Colaboradores.Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();
        }

        public override async Task Atualizar(Colaborador colaborador)
        {
            _lojaContext.Colaboradores.Update(colaborador);
            _lojaContext.Entry(colaborador).Property(x => x.Senha).IsModified = false;
            await _lojaContext.SaveChangesAsync();
        }

        public async Task AtualizarSenha(Colaborador colaborador)
        {
            _lojaContext.Colaboradores.Update(colaborador);

            _lojaContext.Entry(colaborador).Property(x => x.Nome).IsModified = false;
            _lojaContext.Entry(colaborador).Property(x => x.Email).IsModified = false;
            _lojaContext.Entry(colaborador).Property(x => x.Tipo).IsModified = false;

            await _lojaContext.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Colaborador>> ObterTodos()
        {
            return await _lojaContext.Colaboradores.Where(a => a.Tipo != TipoColaborador.GERENTE).ToListAsync();
        }

        public override async Task<IPagedList<Colaborador>> ObterTodosPaginado(int? pagina, string pesquisa)
        {
            var NumeroDaPagina = pagina ?? 1;
            return await _lojaContext.Colaboradores.Where(a => a.Tipo != TipoColaborador.GERENTE).ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }

        public List<Colaborador> ObterPorEmail(string email)
        {
            return _lojaContext.Colaboradores.Where(x => x.Email == email).AsNoTracking().ToList();
        }
    }
}