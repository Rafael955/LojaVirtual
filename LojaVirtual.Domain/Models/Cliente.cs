using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        
        public DateTime Nascimento { get; set; }

        public string Sexo { get; set; }
        
        public string CPF { get; set; }
        
        public string Telefone { get; set; }

        
        public string Email { get; set; }
        
        public string Senha { get; set; }
        

    }
}
