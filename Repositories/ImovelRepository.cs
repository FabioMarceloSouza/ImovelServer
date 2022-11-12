using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ImovelDtos;
using entrevistaServer.Infra;
using entrevistaServer.Models;
using entrevistaServer.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace entrevistaServer.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly ContextDatabase _context;

        public ImovelRepository(ContextDatabase context)
        {
            _context = context;
        }
        public async Task<Imovel> CreateImovel(ImovelRequest request)
        {

            var cliente = await _context.Clientes.FirstOrDefaultAsync(e => e.Id == request.ClienteId);

            if(cliente == null){
                throw new Exception("Cliente não foi encontrado!");
            }

            var data = DateTime.Now;
            var dataOntem = data.AddDays(-1);

            if(request.DataPublicao <= dataOntem)
            {
                throw new Exception("Data não pode ser do dia anterior!");
            }

            var imovel = new Imovel {
                TipoImovel = request.TipoImovel,
                DataPublicao = request.DataPublicao,
                Descricao = request.Descricao,
                ClienteId = request.ClienteId,
                ValorImovel = request.ValorImovel,
                Bairro = request.Bairro,
                Cep = request.Cep,
                Complemento = request.Complemento,
                Localidade = request.Localidade,
                Logradouro = request.Logradouro,
                UF  =request.UF
            };

            _context.Imovels.Add(imovel);
            await _context.SaveChangesAsync();

            imovel.Cliente = cliente;

            return imovel;
        }

        public async Task DeleteImovel(int id)
        {
            var imovel = await _context.Imovels.FirstOrDefaultAsync(e => e.Id == id);

            if(imovel == null){
                throw new Exception("Imovel não foi encontrado!");
            }

            _context.Imovels.Remove(imovel);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Imovel>> GetAllImovels()
        {
           var imovels = await _context.Imovels
           .Include(e => e.Cliente)
           .ToListAsync();

           return imovels;
        }

        public async Task<Imovel> GetImovel(int id)
        {
            var imovel = await _context.Imovels
            .Include(e => e.Cliente)
            .FirstOrDefaultAsync(e => e.Id == id);

            if(imovel == null){
                throw new Exception("Imovel não foi encontrado!");
            }

            return imovel;
        }

        public async Task<Imovel> UpdateImovel(Imovel request)
        {
            var imovel = await _context.Imovels
            .Include(e => e.Cliente)
            .FirstOrDefaultAsync(e => e.Id == request.Id);

            if(imovel == null){
                throw new Exception("Imovel não foi encontrado!");
            }

            var data = DateTime.Now;
            var dataOntem = data.AddDays(-1);

            if(request.DataPublicao <= dataOntem)
            {
                throw new Exception("Data não pode ser do dia anterior!");
            }

            imovel.TipoImovel = request.TipoImovel;
            imovel.Descricao = request.Descricao;
            imovel.ValorImovel = request.ValorImovel;
            imovel.DataPublicao =request.DataPublicao;
            imovel.ClienteId  = request.ClienteId;
            imovel.Cep = request.Cep;
            imovel.Bairro  = request.Bairro;
            imovel.Complemento = request.Complemento;
            imovel.Localidade = request.Localidade;
            imovel.Logradouro = request.Logradouro;
            imovel.UF = request.UF;

            await _context.SaveChangesAsync();

            return imovel;
        }
    }
}