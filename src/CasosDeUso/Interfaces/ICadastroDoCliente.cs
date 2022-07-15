using CasosDeUso.Dtos;
using Dominio;
using System.Threading.Tasks;

namespace CasosDeUso.Interfaces
{
    public interface ICadastroDoCliente
    {
        Task Registrar(ClienteDto clienteDto);
        Task Atualizar(AtualizarClienteDto atualizarClienteDto);
        Task<Cliente> BuscarPorDocumento(string documento);
        Task Excluir(int clienteId);
    }
}
