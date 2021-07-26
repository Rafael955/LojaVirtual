using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IColaboradorRepository : IRepository<Colaborador, Guid>
    {
        Task<Colaborador> Login(string email, string senha);

        List<Colaborador> ObterPorEmail(string email);

        Task AtualizarSenha(Colaborador colaborador);
    }
}