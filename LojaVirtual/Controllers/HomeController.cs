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

        public HomeController(INewsletterEmailRepository newsletterRepo)
        {
            _newsletterRepo = newsletterRepo;
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
                await _newsletterRepo.Add(newsletter);

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

                    ViewData["MsgSucesso"] = "Mensagem de contato enviada com sucesso!";
                }
                else
                {
                    string msgsErro = ExibeMensagensErro(listaMensagens);
                    
                    ViewData["msgErro"] =  msgsErro;
                    ViewData["Contato"] = contato;

                }
            }
            catch
            {
                ViewData["MsgErro"] = "Ops! Tivemos um erro, tente novamente mais tarde!";
            }


            return View("Contato");

        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
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
