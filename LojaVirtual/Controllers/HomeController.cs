using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Domain.Libraries.Email;
using LojaVirtual.Infrastructure.Context;
using LojaVirtual.Domain.Interfaces.IRepositories;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private INewsletterEmailRepository _newsletterRepo;
        private IClienteRepository _clienteRepo;

        public HomeController(INewsletterEmailRepository newsletterRepo, IClienteRepository clienteRepo)
        {
            _newsletterRepo = newsletterRepo;
            _clienteRepo = clienteRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] NewsletterEmail newsletter)
        {
            if (ModelState.IsValid)
            {
                //TODO - Adição no banco de dados
                await _newsletterRepo.Adicionar(newsletter);

                TempData["MsgSucesso"] = "E-mail cadastrado com sucesso! A partir de agora você irá receber promoções especiais em seu e-mail! Fique atento as novidades!";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Contato()
        {
            return View();
        }

        public async Task<IActionResult> ContatoAcao()
        {
            try
            {
                Contato contato = new Contato()
                {
                    Nome = HttpContext.Request.Form["nome"],
                    Email = HttpContext.Request.Form["email"],
                    Texto = HttpContext.Request.Form["texto"]
                };

                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);

                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);

                    TempData["MsgSucesso"] = "Mensagem de contato enviada com sucesso!";
                }
                else
                {
                    string msgsErro = ExibeMensagensErro(listaMensagens);

                    TempData["msgErro"] =  msgsErro;
                    TempData["Contato"] = contato;

                }
            }
            catch
            {
                TempData["MsgErro"] = "Ops! Tivemos um erro, tente novamente mais tarde!";
            }


            return View("Contato");

        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroCliente([FromForm]Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                // TODO - Grava no Banco
                await _clienteRepo.Adicionar(cliente);

                TempData["MsgSucesso"] = "Cadastro realizado com sucesso!";

                //TODO - Implementar redirecionamentos diferentes (Painel, Carrinho de compras etc).

                return RedirectToAction(nameof(CadastroCliente));
            }

            return View(cliente);
        }

        public async Task<IActionResult> CarrinhoCompras()
        {
            return View();
        }

        private string ExibeMensagensErro(List<ValidationResult> listaMensagens)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var msg in listaMensagens)
            {
                sb.Append("- " + msg.ErrorMessage + "</br>");
            }

            return sb.ToString();
        }
    }
}
