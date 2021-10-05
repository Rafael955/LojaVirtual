using LojaVirtual.Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index(int? pagina, string pesquisa)
        {
            var produtos = await _produtoRepository.ObterTodosPaginado(pagina, pesquisa);
            return View(produtos);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

    }
}