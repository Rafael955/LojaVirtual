using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string Tipo { get; set; }
    }

    public abstract class TipoColaborador
    {
        public static string COMUM = "C";
        public static string GERENTE = "G";
    }
}