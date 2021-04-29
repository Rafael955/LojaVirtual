using LojaVirtual.Domain.Libraries;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Domain.Models
{
    public class NewsletterEmail : Entity
    {
        [Required(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro001")]
        [EmailAddress(ErrorMessageResourceType = typeof(MsgErro), ErrorMessageResourceName = "MsgErro004")]
        public string Email { get; set; }
    }
}