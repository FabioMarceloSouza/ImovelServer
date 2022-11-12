using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevistaServer.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } =  true;
        public string CpfOuCnpj { get; set; }
        public List<Imovel> Imovels { get; set; }
    }
}