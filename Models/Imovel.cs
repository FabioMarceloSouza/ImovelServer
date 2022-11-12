using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Enums;

namespace entrevistaServer.Models
{
    public class Imovel
    {
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
        public Cliente Cliente { get; set; }
    }
}