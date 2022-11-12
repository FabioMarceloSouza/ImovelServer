using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Models;
using Microsoft.EntityFrameworkCore;

namespace entrevistaServer.Infra
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Imovel> Imovels { get; set; }
    }
}