using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        [HttpGet("Visualizar")]
        public IActionResult Visualizar()
        {
            Produto produto = GetProduto();
            return View(produto);
            //return new ContentResult()
            //{
            //    Content = "<h1>Produto -> Visualizar</h1>",
            //    ContentType = "text/html"
            //};
        }

        private Produto GetProduto()
        {
            return new Produto()
            {
                Nome = "Xbox One x",
                Descricao = "Jogue em 4k",
                Valor = 2000.00M
            }; ;
        }
    }
}
