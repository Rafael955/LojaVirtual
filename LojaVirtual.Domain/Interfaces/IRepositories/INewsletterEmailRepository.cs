using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface INewsletterEmailRepository
    {
        Task Add(NewsletterEmail newsletter);
    }
}
