using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ClienteDtos;
using entrevistaServer.Infra;
using entrevistaServer.Models;

namespace entrevistaServer.Repositories.IRepositories
{
    public interface IClienteRepository
    {
        Task<ClienteResponse> CreateCliente(ClienteRequest request);   
        Task<List<ClienteResponse>>  GetAllClientes();
        Task<ClienteResponse> GetCliente(int id);
        Task<ClienteResponse> UpdateCliente(Cliente request);
        Task DeleteCliente(int id);
    }
}