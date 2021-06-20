using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Libraries.Lang;
using LojaVirtual.Domain.Libraries.Texto;
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
        private GerenciarEmail _gerenciarEmail;

        public ColaboradorController(IColaboradorRepository colaboradorRepository, GerenciarEmail gerenciarEmail)
        {
            _colaboradorRepository = colaboradorRepository;
            _gerenciarEmail = gerenciarEmail;
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
            ModelState.Remove("Senha");
            if (ModelState.IsValid)
            {
                colaborador.Senha = await KeyGenerator.GetUniqueKey(8);

                await _colaboradorRepository.Adicionar(colaborador);

                _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);

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

        [HttpGet("[action]/{id:guid}")]
        public async Task<IActionResult> GerarSenha(Guid id)
        {
            Domain.Models.Colaborador colaborador = await _colaboradorRepository.ObterPorId(id);

            colaborador.Senha = await KeyGenerator.GetUniqueKey(8);

            await _colaboradorRepository.Atualizar(colaborador);

            //TODO - Enviar e-mail com senha para colaborador
            _gerenciarEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);

            TempData["MsgSucesso"] = MsgSucesso.MsgColaboradorNovaSenhaSucesso;

            return RedirectToAction(nameof(Index));
        }
    }
}