using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Libraries.Lang;
using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Domain.Models
{
    public class NewsletterEmail : Entity<Guid>
    {
        public NewsletterEmail()
        {
            Id = Guid.NewGuid();
        }

        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [EmailAddress(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro004")]
        public string Email { get; set; }
    }
}