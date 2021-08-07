using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Libraries.Filtro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Colaborador = LojaVirtual.Domain.Models.Colaborador;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private IColaboradorRepository _colaboradorRepo;
        private LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository colaboradorRepo, LoginColaborador loginColaborador)
        {
            _colaboradorRepo = colaboradorRepo;
            _loginColaborador = loginColaborador;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] _Colaborador colaborador)
        {
            _Colaborador colaboradorDb = await _colaboradorRepo.Login(colaborador.Email, colaborador.Senha);

            if (colaboradorDb != null)
            {
                _loginColaborador.Login(colaboradorDb);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }

            TempData["MsgErro"] = "Usuário não encontrado, por favor verifique o e-mail e senha digitados!";
            return View();
        }

        [ColaboradorAutorizacao]
        [ValidateHttpReferer]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        [ColaboradorAutorizacao]
        public IActionResult Painel()
        {
            return View();
        }

        public IActionResult RecuperarSenha()
        {
            return View();
        }

        public IActionResult CadastrarNovaSenha()
        {
            return View();
        }
    }
}