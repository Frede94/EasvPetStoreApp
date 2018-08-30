using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data
{
    public class FakeDB
    {
        public static int id = 1;
        public static IEnumerable<Pet> Pets;

        public static void InitializeData()
        {
            var pet1 = new Pet()
            {
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
                Name = "Peter",
                Type = "And",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 123
            };
            Pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6, pet7, pet8 };
        }

    }
}
