using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    //TODO - Habilitar verificação de Login
    //[ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IActionResult> Index(int? pagina)
        {
            var categorias = await _categoriaRepository.ObterTodosPaginado(pagina);
            return View(categorias);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Categorias = await GetCategorias();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepository.Adicionar(categoria);

                TempData["MsgSucesso"] = $"Categoria {categoria.Nome} cadastrada com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Categoria categoria)
        {
            return View();
        }

        [HttpGet("{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            return View();
        }

        private async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _categoriaRepository.ObterTodos();
        }
    }
}