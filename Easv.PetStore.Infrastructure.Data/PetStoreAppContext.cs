using Easv.PetStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data
{
    public class PetStoreAppContext : DbContext
    {
        public PetStoreAppContext(DbContextOptions<PetStoreAppContext> opt )
           : base(opt){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.PetOwner)
                .WithMany(o => o.Pets)
                .OnDelete(DeleteBehavior.SetNull);

                //.HasMany(p => p.PetOwner)
                //.WithOne(o => o.Pet);
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }
    }
}
