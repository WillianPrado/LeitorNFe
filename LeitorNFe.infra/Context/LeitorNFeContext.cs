using LeitorNFe.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeitorNFe.Infra.Context
{
    public class LeitorNFeContext : DbContext 
    {
        public LeitorNFeContext(DbContextOptions<LeitorNFeContext> options) : base(options)
        {
        }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Emit> Emitents { get; set; }
        public DbSet<Prod> Products { get; set; }
        public DbSet<Dest> Recipients { get; set; }
    }
}
