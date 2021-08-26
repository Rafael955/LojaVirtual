using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Libraries.Filtro;
using LojaVirtual.Domain.Libraries.Lang;
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
    [Route("[area]/[controller]")]
    [ColaboradorAutorizacao]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? pagina)
        {
            var clientes = await _clienteRepository.ObterTodosPaginado(pagina);
            return View(clientes);
        }

        [HttpGet("[action]/{id:guid}")]
        [ValidateHttpReferer]
        public async Task<IActionResult> AtivarDesativar(Guid id)
        {
            Cliente cliente = await _clienteRepository.ObterPorId(id);

            if (cliente.Situacao == Situacao.ATIVO)
                cliente.Situacao = Situacao.INATIVO;
            else
                cliente.Situacao = Situacao.ATIVO;

            await _clienteRepository.Atualizar(cliente);

            TempData["MsgSucesso"] = MsgSucesso.MsgClienteAltSucesso;

            return RedirectToAction(nameof(Index));
        }
    }
}