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
    public class ImagemRepository : Repository<Imagem, Guid>, IImagemRepository
    {
        private LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public ImagemRepository(LojaVirtualContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async Task ExcluirImagensDoProduto(int ProdutoId)
        {
            List<Imagem> imagens = _lojaContext.Imagens.Where(x => x.ProdutoId == ProdutoId).ToList();
            _lojaContext.Imagens.RemoveRange(imagens);
            await Salvar();
        }

        public override Task<IPagedList<Imagem>> ObterTodosPaginado(int? pagina, string pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}