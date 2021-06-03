using LojaVirtual.Domain.Models;
using System;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface INewsletterEmailRepository : IRepository<NewsletterEmail, Guid>
    {
    }
}