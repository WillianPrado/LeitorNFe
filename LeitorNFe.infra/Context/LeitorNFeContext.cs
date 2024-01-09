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
        public DbSet<Emit> Emits { get; set; }
        public DbSet<Prod> Prods { get; set; }
        public DbSet<Dest> Dests { get; set; }

        public DbSet<ICMSTot> iCMSTots { get; set; }
        public DbSet<InfNFe> InfNFe { get; set; }
        public DbSet<InfProt> InfProt { get; set; }

        public DbSet<Ide> Ides { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Prod>()
            //    .Property(p => p.qCom)
            //    .HasColumnType("decimal(18, 10)");

            //modelBuilder.Entity<Prod>()
            //    .Property(p => p.vUnCom)
            //    .HasColumnType("decimal(18, 10)");

            //modelBuilder.Entity<Prod>()
            //    .Property(p => p.vProd)
            //    .HasColumnType("decimal(18, 10)");

            //modelBuilder.Entity<Prod>()
            //    .Property(p => p.qTrib)
            //    .HasColumnType("decimal(18, 10)");

            //modelBuilder.Entity<Prod>()
            //    .Property(p => p.vUnTrib)
            //    .HasColumnType("decimal(18, 10)");
            
            //modelBuilder.Entity<Prod>()
            //    .Property(p => p.vDesc)
            //    .HasColumnType("decimal(18, 10)");

            //modelBuilder.Entity<ICMSTot>()
            //    .Property(p => p.vNF)
            //    .HasColumnType("decimal(18, 10)");

            // Outras configurações para as propriedades da classe...
        }
    }
}
