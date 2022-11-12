using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevistaServer.Dtos.ClienteDtos
{
    public class ClienteRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CpfOuCnpj { get; set; }
    }
}