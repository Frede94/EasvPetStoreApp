using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetStoreAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var pet1 = ctx.Pets.Add(new Pet()
            {
                
                Name = "Pjuske",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Brun",
                PrevOwner = "Lars",
                Price = 2000.00,
                PetOwner = new Owner
                {
                    OwnerId = 1
                }
            }).Entity;
            var pet2 = ctx.Pets.Add(new Pet()
            {
                
                Name = "JohnBob",
                Type = "Kat",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Hvid",
                PrevOwner = "John",
                Price = 150.00,
                PetOwner = new Owner
                {
                    OwnerId = 2
                }
            }).Entity;
            var pet3 = ctx.Pets.Add(new Pet()
            {
                
                Name = "Ib",
                Type = "Gås",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Grå",
                PrevOwner = "Karl",
                Price = 350.00,
                PetOwner = new Owner
                {
                    OwnerId = 1
                }
            }).Entity;
            var pet4 = ctx.Pets.Add(new Pet()
            {
                
                Name = "Killer",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 5000.00,
                PetOwner = new Owner
                {
                    OwnerId = 2
                }
            }).Entity;
            var pet5 = ctx.Pets.Add(new Pet()
            {
                
                Name = "Gunner",
                Type = "Gås",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 56454,
                PetOwner = new Owner
                {
                    OwnerId = 2
                }
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
