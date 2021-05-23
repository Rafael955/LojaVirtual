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

        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set
            {
                if (value.Equals(TipoColaborador.COMUM) || value.Equals(TipoColaborador.GERENTE))
                {
                    _tipo = value;
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