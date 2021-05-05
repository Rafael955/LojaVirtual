using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Colaborador : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Tipo
        {
            get { return Tipo; }
            set
            {
                if (value.Equals(TipoColaborador.COMUM) && value.Equals(TipoColaborador.GERENTE))
                {
                    Tipo = value;
                }
                else
                {
                    throw new Exception("TipoColaborador Inválido!");
                }
            }
        }
    }

    public abstract class TipoColaborador
    {
        public static string COMUM = "C";
        public static string GERENTE = "G";
    }
}