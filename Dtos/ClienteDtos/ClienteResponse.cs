using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using entrevistaServer.Enums;
using entrevistaServer.Models;

namespace entrevistaServer.Dtos.ClienteDtos
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } =  true;
        public string CpfOuCnpj { get; set; }
        public List<ImovelResponseCliente> Imovels { get; set; }
    }


    public class ImovelResponseCliente {
        public int Id { get; set; }
        public TipoImovel TipoImovel { get; set; }
        public double ValorImovel { get; set; }
        public DateTime DataPublicao { get; set; }
        public string Descricao { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public int ClienteId { get; set; }
    }
}