using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data
{
    public class FakeDB
    {
        public static int petId = 1;
        public static IEnumerable<Pet> Pets;

        public static int ownerId = 1;
        public static IEnumerable<Owner> Owners;

        public static void InitializeData()
        {
            var pet1 = new Pet()
            {
                Id = petId++,
                Name = "Pjuske",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Brun",
                PrevOwner = "Lars",
                Price = 2000.00

            };
            var pet2 = new Pet()
            {
                Id = petId++,
                Name = "JohnBob",
                Type = "Kat",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Hvid",
                PrevOwner = "John",
                Price = 150.00
            };
            var pet3 = new Pet()
            {
                Id = petId++,
                Name = "Ib",
                Type = "Gås",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Grå",
                PrevOwner = "Karl",
                Price = 350.00
            };
            var pet4 = new Pet()
            {
                Id = petId++,
                Name = "Killer",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 5000.00
            };
            var pet5 = new Pet()
            {
                Id = petId++,
                Name = "Gunner",
                Type = "Gås",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 56454
            };
            var pet6 = new Pet()
            {
                Id = petId++,
                Name = "Bølle",
                Type = "Kat",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 987
            };
            var pet7 = new Pet()
            {
                Id = petId++,
                Name = "Ulle",
                Type = "Fugl",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 872342.00
            };
            var pet8 = new Pet()
            {
                Id = petId++,
                Name = "Peter",
                Type = "And",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 123
            };
            Pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6, pet7, pet8 };

            var owner1 = new Owner()
            {
                OwnerId = ownerId++,
                First_name = "Johny",
                Last_name = "Bravo",
                Adress = "Hus 5",
                Pets = new Pet()
                {
                    Id = pet2.Id,
                    Name = pet2.Name,
                    Type = pet2.Type,
                    Birthdate = pet2.Birthdate,
                    SoldDate = pet2.SoldDate,
                    Color = pet2.Color,
                    PrevOwner = pet1.PrevOwner,
                    Price = pet2.Price
                }
            };
            var owner2 = new Owner()
            {
                OwnerId = ownerId++,
                First_name = "Karl",
                Last_name = "Nabo",
                Adress = "Hus 8",
                Pets = new Pet()
                {
                    Id = pet1.Id,
                    Name = pet1.Name,
                    Type = pet1.Type,
                    Birthdate = pet1.Birthdate,
                    SoldDate = pet1.SoldDate,
                    Color = pet1.Color,
                    PrevOwner = pet1.PrevOwner,
                    Price = pet1.Price
                }
            };
            Owners = new List<Owner> { owner1, owner2 };
        }

    }
}
