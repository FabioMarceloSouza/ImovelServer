using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ImovelDtos;
using entrevistaServer.Models;

namespace entrevistaServer.Repositories.IRepositories
{
    public interface IImovelRepository
    {
        Task<Imovel> CreateImovel(ImovelRequest request);   
        Task<List<Imovel>>  GetAllImovels();
        Task<Imovel> GetImovel(int id);
        Task<Imovel> UpdateImovel(Imovel request);
        Task DeleteImovel(int id);
    }
}