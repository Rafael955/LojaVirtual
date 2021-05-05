using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Libraries
{
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCliente _loginCliente;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));

            Cliente cliente = _loginCliente.ObterCliente();

            if (cliente == null)
            {
                context.Result = new ContentResult { Content = "Acesso Negado!" };
            }
        }
    }
}

/**
 * Tipos de Filtros
 * - Autorização
 * - Recurso
 * - Ação
 * - Exceção
 * - Resultado
 */