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
            return new ContentResult()
            {
                Content = "<h1>Produto -> Visualizar</h1>",
                ContentType = "text/html"
            };
        }
    }
}
