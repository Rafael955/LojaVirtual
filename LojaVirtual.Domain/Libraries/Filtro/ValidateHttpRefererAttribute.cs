using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Libraries.Filtro
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Este método é executado antes de passarmos pelos controlador
            string referer = context.HttpContext.Request.Headers["Referer"].ToString(); //referer é uma prop do cabeçalho da requisição http que pode ser enviada ou não.

            if (string.IsNullOrEmpty(referer)) //se referer for nulo quer dizer que houve tentativa de acessar diretamente por url um método como, por exemplo, excluir um conta, se for o caso retornamos um ContentResult bloqueando o acesso, só podemos excluir uma conta estando logado e clicando no botão de dentro do próprio site.
            {
                context.Result = new ContentResult()
                {
                    Content = "Acesso negado!"
                };
            }
            else
            {
                Uri uri = new Uri(referer);

                string hostReferer = uri.Host;
                string hostServidor = context.HttpContext.Request.Host.Host;

                if (hostReferer != hostServidor)
                {
                    context.Result = new ContentResult()
                    {
                        Content = "Acesso negado!"
                    };
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Este método é executado após passarmos pelos controlador
            //throw new NotImplementedException();
            return;
        }
    }
}