using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Libraries.Validacao
{
    public class EmailUnicoColaboradorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //TODO - Pegar o valor do campo E-mail, Obter o Repository do Colaborador, Fazer Verificação.
            //1 - Pegar o valor do campo E-mail
            string email = value as string;
            //2 - Obter o Repository do Colaborador
            IColaboradorRepository _colaboradorRepository = (IColaboradorRepository)validationContext.GetService(typeof(IColaboradorRepository));

            List<Colaborador> colaboradores = new List<Colaborador>();

            colaboradores = _colaboradorRepository.ObterPorEmail(email);

            Colaborador objColaborador = (Colaborador)validationContext.ObjectInstance;

            if (colaboradores.Count > 1)
            {
                return new ValidationResult("E-mail já existente!");
            }

            if (colaboradores.Count == 1 && objColaborador.Id != colaboradores[0].Id)
            {
                return new ValidationResult("E-mail já existente!");
            }

            return ValidationResult.Success;
        }
    }
}