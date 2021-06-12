using LojaVirtual.Domain.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class Colaborador : Entity<Guid>
    {
        public Colaborador()
        {
            Id = Guid.NewGuid();
        }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(4, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [EmailAddress(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro004")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(6, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        public string Senha { get; set; }

        [NotMapped]
        public string ConfirmaSenha { get; set; }

        private string _tipo;

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
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