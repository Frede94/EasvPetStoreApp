using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using Easv.PetStore.Infrastructure.Data.Repositories;
using System;

namespace Easv.PetStore.ConsoleApp
{

    class Printer
    {
        private IPetRepository petRepository;

        public Printer()
        {
            

            petRepository = new PetRepository();
            //Infrastructure.Data
            //Initialise Data - Seed Database
            var pet1 = new Pet()
            {
                Name = "Pjuske",
                Type = "Hund",
                Birthdate = new DateTime (2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Brun",
                PrevOwner = "Lars",
                Price = 2000.00

            };
            petRepository.Create(pet1);
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
            petRepository.Create(pet2);
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
            petRepository.Create(pet3);
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
            petRepository.Create(pet4);

            //UI
            string[] menuEnhender =
            {
                "List af alle Pet",
                "Søg efter Pet type",
                "Tilføj pet",
                "Fjern pet",
                "Ændre pet",
                "Sorter efter pris",
                "Få 5 billigste pets",
                "Exit"
            };

            var valg = PetMenu(menuEnhender);

            while (valg != 8)
            {
                switch (valg)
                {
                    case 1:
                        VisFilm();
                        break;
                    case 2:
                        Console.WriteLine("Nope");
                        break;
                    case 3:
                        TilføjFilm();                        
                        break;
                    case 4:
                        SletFilm();                        
                        break;
                    case 5:
                        ÆndreFilm();
                        break;
                    case 6:
                        Console.WriteLine("Nope");
                        break;
                    case 7:
                        Console.WriteLine("Nope");
                        break;
                    default:
                        break;
                }
                valg = PetMenu(menuEnhender);
            }
            Console.WriteLine("Farvel");


            Console.ReadLine();
        }
        private Pet FindPetMedID()
        {
            Console.WriteLine("Skriv id på Pet ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID er altid et tal");
            }

            return petRepository.ReadById(id);

        }

        private void ÆndreFilm()
        {
            var pet = FindPetMedID();

            Console.WriteLine("Skriv Pets Navn");
            pet.Name = Console.ReadLine();
            Console.WriteLine("Skriv Pets Type");
            pet.Type = Console.ReadLine();
            //Console.WriteLine("Skriv Pets Birthdate");
            //pet.Birthdate = Console.ReadLine();
            //Console.WriteLine("Skriv Pets SoldDate");
            //pet.SoldDate = Console.ReadLine();
            Console.WriteLine("Skriv Pets Color");
            pet.Color = Console.ReadLine();
            Console.WriteLine("Skriv Pets PreviousOwner");
            pet.PrevOwner = Console.ReadLine();
            Console.WriteLine("Skriv Pets Price");
            pet.Price = double.Parse(Console.ReadLine());

        }

        private void SletFilm()
        {
            var videoFundet = FindPetMedID();

            if (videoFundet != null)
            {
                petRepository.delete(videoFundet.Id);
            }
        }

        private void TilføjFilm()
        {
            //UI            
            Console.WriteLine("Skriv Pets Navn");
            var name = Console.ReadLine();
            Console.WriteLine("Skriv Pets Type");
            var type = Console.ReadLine();
            //Console.WriteLine("Skriv Pets Birthdate");
            //var birthdate = Console.ReadLine();
            //Console.WriteLine("Skriv Pets SoldDate");
            //var soldDate = Console.ReadLine();
            Console.WriteLine("Skriv Pets Color");
            var color = Console.ReadLine();
            Console.WriteLine("Skriv Pets PreviousOwner");
            var prevOwner = Console.ReadLine();
            Console.WriteLine("Skriv Pets Price");
            var price = double.Parse(Console.ReadLine());            
            
            var vid = new Pet
            {
                Name = name,
                Type = type,
                //Birthdate = birthDate,
                //SoldDate = soldDate,
                Color = color,
                PrevOwner = prevOwner,
                Price = price
            };
            petRepository.Create(vid);
        }

        private void VisFilm()
        {
            Console.WriteLine("\nListe af film");
                       
            var pets = petRepository.ReadAll();
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} | Navn: {pet.Name} | Type: {pet.Type} " +
                    $"| Birthdate: {pet.Birthdate} | Solddate: {pet.SoldDate}" +
                    $" | Color: {pet.Color} | Previous Owner: {pet.PrevOwner} | Price: {pet.Price}");

            }
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("\n");
        }


        //UI
        public static int PetMenu(string[] menuEnhender)
        {
            Console.WriteLine("Skriv et tal for at vælge: \n");

            for (int i = 0; i < menuEnhender.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuEnhender[i]);
            }
            int valg;
            while (!int.TryParse(Console.ReadLine(), out valg) || valg < 1 || valg > 8)
            {
                Console.WriteLine("Det ikke et tal på listen");
            }
            Console.WriteLine("Valg: " + valg);
            return valg;

        }
    }
}
