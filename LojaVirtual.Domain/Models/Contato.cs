using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Domain.Libraries;

namespace LojaVirtual.Domain.Models
{
    public class Contato : Entity
    {
        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(4, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [EmailAddress(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro004")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [MinLength(10, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro002")]
        [MaxLength(1000, ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro003")]
        public string Texto { get; set; }
    }
}
