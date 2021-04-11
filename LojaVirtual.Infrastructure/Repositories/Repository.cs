using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Infrastructure.Repositories
{
    public class Repository<T> where T : Entity
    {
        protected LojaVirtualContext _context;

        protected Repository(LojaVirtualContext context)
        {
            _context = context;
        }
    }
}
