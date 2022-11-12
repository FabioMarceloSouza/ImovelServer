using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ClienteDtos;
using entrevistaServer.Infra;
using entrevistaServer.Models;
using entrevistaServer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace entrevistaServer.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextDatabase _context;

        public ClienteRepository(ContextDatabase context)
        {
            _context = context;
        }
        public async Task<ClienteResponse> CreateCliente(ClienteRequest request)
        {
            var cliente  = new Cliente {
                Name = request.Name,
                Email = request.Email,
                CpfOuCnpj = request.CpfOuCnpj
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var response = new ClienteResponse {
                Id = cliente.Id,
                Active = cliente.Active,
                CpfOuCnpj =cliente.CpfOuCnpj,
                Name = cliente.Name,
                Email = cliente.Email
            };

            return response;
        }

        public async Task DeleteCliente(int id)
        {
            var cliente  =  await _context.Clientes.FirstOrDefaultAsync(e => e.Id == id);

            if(cliente == null)
                throw new Exception("Cliente não encontrado!");

            cliente.Active = false;
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClienteResponse>> GetAllClientes()
        {
            var clientes  = await _context.Clientes
            .Include(e => e.Imovels)
            .ToListAsync();

            var response = new List<ClienteResponse>();

            foreach (var item in clientes) 
            {
                var resposeImovelCliente = new List<ImovelResponseCliente>();

                foreach (var imovel in item.Imovels)
                {
                    resposeImovelCliente.Add(new ImovelResponseCliente {
                    Id = imovel.Id,
                    Bairro = imovel.Bairro,
                    Cep = imovel.Cep,
                    ClienteId = imovel.ClienteId,
                    Complemento = imovel.Complemento,
                    DataPublicao = imovel.DataPublicao,
                    Descricao= imovel.Descricao,
                    Localidade =imovel.Localidade,
                    Logradouro = imovel.Logradouro,
                    TipoImovel = imovel.TipoImovel,
                    UF = imovel.UF,
                    ValorImovel = imovel.ValorImovel
                });
                }
   

                response.Add(new ClienteResponse {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    CpfOuCnpj = item.CpfOuCnpj,
                    Active = item.Active,
                    Imovels = resposeImovelCliente
                });
            }

            return response;
        
        }

        public async Task<ClienteResponse> GetCliente(int id)
        {
            var cliente  =  await _context.Clientes
            .Include(x => x.Imovels)
            .FirstOrDefaultAsync(e => e.Id == id);

            if(cliente == null)
                throw new Exception("Cliente não encontrado!");

            var resposeImovelCliente = new List<ImovelResponseCliente>();

            foreach (var item in cliente.Imovels)
            {
                resposeImovelCliente.Add(new ImovelResponseCliente {
                    Id = item.Id,
                    Bairro = item.Bairro,
                    Cep = item.Cep,
                    ClienteId = item.ClienteId,
                    Complemento = item.Complemento,
                    DataPublicao = item.DataPublicao,
                    Descricao= item.Descricao,
                    Localidade =item.Localidade,
                    Logradouro = item.Logradouro,
                    TipoImovel = item.TipoImovel,
                    UF = item.UF,
                    ValorImovel = item.ValorImovel
                });
            }

            var response = new ClienteResponse {
                Id = cliente.Id,
                Name = cliente.Name,
                Email = cliente.Email,
                CpfOuCnpj = cliente.CpfOuCnpj,
                Active = cliente.Active,
                Imovels = resposeImovelCliente
            };

            return response;
        }

        public async Task<ClienteResponse> UpdateCliente(Cliente request)
        {
            var cliente  =  await _context.Clientes.FirstOrDefaultAsync(e => e.Id == request.Id);

            if(cliente == null)
                throw new Exception("Cliente não encontrado!");

            cliente.Name = request.Name;
            cliente.Email =  request.Email;
            cliente.CpfOuCnpj = request.CpfOuCnpj;
            cliente.Active = request.Active;

            await _context.SaveChangesAsync();

             var response = new ClienteResponse {
                Id = cliente.Id,
                Name = cliente.Name,
                Email = cliente.Email,
                CpfOuCnpj = cliente.CpfOuCnpj,
                Active = cliente.Active
            };

            return response;

        }
    }
}