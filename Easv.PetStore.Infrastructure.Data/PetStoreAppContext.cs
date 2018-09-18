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

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }
    }
}
