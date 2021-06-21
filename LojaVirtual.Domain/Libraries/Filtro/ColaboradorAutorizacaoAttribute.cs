using LojaVirtual.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaVirtual.Domain.Libraries
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private string _tipoColaboradorAutorizado;

        public ColaboradorAutorizacaoAttribute(string TipoColaboradorAutorizado = TipoColaborador.COMUM)
        {
            _tipoColaboradorAutorizado = TipoColaboradorAutorizado;
        }

        private LoginColaborador _loginColaborador;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));

            Colaborador colaborador = _loginColaborador.ObterColaborador();

            if (colaborador == null)
            {
                //context.Result = new ContentResult { Content = "Acesso Negado!" };
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else
            {
                if (colaborador.Tipo == TipoColaborador.COMUM && _tipoColaboradorAutorizado == TipoColaborador.GERENTE)
                {
                    context.Result = new ForbidResult();
                }
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