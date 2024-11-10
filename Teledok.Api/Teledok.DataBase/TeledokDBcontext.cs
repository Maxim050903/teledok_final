using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using teledok.Teledok.DataBase.Entities;

namespace teledok.Teledok.DataBase
{
    public class TeledokDBcontext : DbContext
    {
        public TeledokDBcontext(DbContextOptions<TeledokDBcontext> options)
            : base(options)
        {
        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<FounderEntity> Founders { get; set; }
    }
}
