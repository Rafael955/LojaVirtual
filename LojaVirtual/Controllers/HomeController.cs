using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private INewsletterEmailRepository _newsletterRepo;
        private IClienteRepository _clienteRepo;
        private LoginCliente _loginCliente;
        private GerenciarEmail _gerenciarEmail;

        public HomeController(INewsletterEmailRepository newsletterRepo, IClienteRepository clienteRepo, LoginCliente loginCliente, GerenciarEmail gerenciarEmail)
        {
            _newsletterRepo = newsletterRepo;
            _clienteRepo = clienteRepo;
            _loginCliente = loginCliente;
            _gerenciarEmail = gerenciarEmail;
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

        public async Task<IActionResult> ContatoAcao(CancellationToken cancellationtoken)
        {
            try
            {
                await Task.Run(() =>
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
                        _gerenciarEmail.EnviarContatoPorEmail(contato);

                        TempData["MsgSucesso"] = "Mensagem de contato enviada com sucesso!";
                    }
                    else
                    {
                        string msgsErro = ExibeMensagensErro(listaMensagens);

                        TempData["msgErro"] = msgsErro;
                        TempData["Contato"] = contato;
                    }
                }, cancellationtoken);
            }
            catch (TaskCanceledException)
            {
            }
            catch
            {
                TempData["MsgErro"] = "Ops! Tivemos um erro, tente novamente mais tarde!";
            }

            return View("Contato");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Cliente cliente)
        {
            Cliente clienteDB = await _clienteRepo.Login(cliente.Email, cliente.Senha);

            if (clienteDB != null)
            {
                //HttpContext.Session.Set("Id", new byte[] { 52 });
                //HttpContext.Session.SetString("Email", cliente.Email);
                //HttpContext.Session.SetInt32("Idade", 32);

                _loginCliente.Login(clienteDB);

                // return await Task.FromResult(new ContentResult { Content = "Logado!" });

                return new RedirectResult(Url.Action(nameof(Painel)));
            }

            TempData["MsgErro"] = "Usuário não encontrado, por favor verifique o e-mail e senha digitados!";
            return View();
        }

        [HttpGet]
        [ClienteAutorizacao]
        public async Task<IActionResult> Painel()
        {
            return new ContentResult() { Content = "Este é o Painel do Cliente." };
        }

        [HttpGet]
        public async Task<IActionResult> CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroCliente([FromForm] Cliente cliente)
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