using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            ViewBag.Categorias = await GetCategorias();
            return View();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Atualizar(int id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);
            ViewBag.Categorias = await GetCategorias(id);

            return View(categoria);
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Atualizar([FromForm] Categoria categoria, int id)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepository.Atualizar(categoria);

                TempData["MsgSucesso"] = $"Categoria atualizada com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = await GetCategorias(id);
            return View();
        }

        [HttpGet("{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> GetCategorias(int id = 0)
        {
            var categorias = await _categoriaRepository.ObterTodos();

            if (id != 0)
                return categorias.Where(x => x.Id != id).Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            else
                return categorias.Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
        }
    }
}