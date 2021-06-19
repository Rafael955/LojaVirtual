using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries.Lang;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [Route("[area]/[controller]")]
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? pagina)
        {
            var colaboradores = await _colaboradorRepository.ObterTodosPaginado(pagina);
            return View(colaboradores);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Cadastrar([FromForm] Domain.Models.Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                await _colaboradorRepository.Adicionar(colaborador);

                TempData["MsgSucesso"] = MsgSucesso.MsgColaboradorAddSucesso;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var colaborador = await _colaboradorRepository.ObterPorId(id);
            return View(colaborador);
        }

        [HttpPost("[action]/{id:guid}")]
        public async Task<IActionResult> Atualizar([FromForm] Domain.Models.Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                await _colaboradorRepository.Atualizar(colaborador);

                TempData["MsgSucesso"] = MsgSucesso.MsgColaboradorAltSucesso;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var colaborador = await _colaboradorRepository.ObterPorId(id);
            await _colaboradorRepository.Remover(colaborador);

            TempData["MsgSucesso"] = MsgSucesso.MsgColaboradorDelSucesso;

            return RedirectToAction(nameof(Index));
        }
    }
}