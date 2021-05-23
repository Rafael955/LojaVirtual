using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Domain.Libraries
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginColaborador _loginColaborador;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));

            Colaborador colaborador = _loginColaborador.ObterColaborador();

            if (colaborador == null)
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