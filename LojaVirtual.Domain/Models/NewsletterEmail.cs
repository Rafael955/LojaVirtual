using LojaVirtual.Domain.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Domain.Models
{
    public class NewsletterEmail : Entity
    {
        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [EmailAddress(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro004")]
        public string Email { get; set; }
    }
}
