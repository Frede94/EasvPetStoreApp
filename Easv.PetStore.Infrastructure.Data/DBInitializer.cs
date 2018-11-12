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

            var owner1 = ctx.Owners.Add(new Owner()
            {
                First_name = "Johny",
                Last_name = "Bravo",
                Adress = "Hus 5",
            }).Entity;
            var owner2 = ctx.Owners.Add(new Owner()
            {
                First_name = "jens",
                Last_name = "Olive",
                Adress = "Hus 1337",
            }).Entity;
            var owner3 = ctx.Owners.Add(new Owner()
            {
                First_name = "Karl",
                Last_name = "Nabo",
                Adress = "Hus 8",
            }).Entity;
            var owner4 = ctx.Owners.Add(new Owner()
            {
                First_name = "Ole",
                Last_name = "Jensen",
                Adress = "Vejen 10",
            }).Entity;
            var pet1 = ctx.Pets.Add(new Pet()
            {

                Name = "Pjuske",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Brun",
                PrevOwner = "Lars",
                Price = 2000.00,
                PetOwner = owner3
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
                PetOwner = owner1
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
                PetOwner = owner2
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
                PetOwner = owner2
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
                PetOwner = owner4
            }).Entity;

            ctx.SaveChanges();


            List<Pet> items = new List<Pet>
            {
                new Pet
                {
                Name = "Killer",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 5000.00,
                PetOwner = owner2
                },
                new Pet
                {
                Name = "Gunner",
                Type = "Gås",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 56454,
                PetOwner = owner4
                }
            };


            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.Pets.AddRange(items);
            ctx.Users.AddRange(users);
            ctx.SaveChanges();

        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

