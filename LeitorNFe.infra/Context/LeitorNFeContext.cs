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

        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Emitent> Emitents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Destinatario> Recipients { get; set; }
    }
}
