using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class ClienteMockRepository : MockRepository<Cliente, Guid>, IClienteRepository
    {
        public override async Task Adicionar(Cliente entity)
        {
            await Task.Run(() => _lista.Add(entity));
        }

        public override async Task Atualizar(Cliente entity)
        {
            await Task.Run(() =>
            {
                Cliente client = _lista.FirstOrDefault(x => x.Id == entity.Id);

                if (client != null)
                {
                    client.CPF = entity.CPF;
                    client.Email = entity.Email;
                    client.Nascimento = entity.Nascimento;
                    client.Nome = entity.Nome;
                    client.Senha = entity.Senha;
                    client.Sexo = entity.Sexo;
                    client.Telefone = entity.Telefone;
                };
            });
        }

        public async Task<Cliente> Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}