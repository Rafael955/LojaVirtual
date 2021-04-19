using LojaVirtual.Domain.Libraries;
using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Domain.Models
{
    public class Cliente : Entity
    {
        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(4, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        public string Sexo { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        public string CPF { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        public string Telefone { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [EmailAddress(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro004")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(6, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        public string Senha { get; set; }
    }
}