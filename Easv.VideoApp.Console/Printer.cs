using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using Easv.PetStore.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Easv.PetStore.ConsoleApp
{
    //hej


    public class Printer: IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;                       
        }

        //UI
        public void StartUI()
        {
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
                        var pets = _petService.GetAllPets();                        
                        ShowPets(pets);                        
                        break;
                    case 2:
                        var searchType = PrintFintPetByType();
                        var result = _petService.FindPetByType(searchType);
                        foreach (var searchPet in result)
                        {
                            Console.WriteLine($"Name: {searchPet.Name} | Type: {searchPet.Type} | Birthdate: {searchPet.Birthdate}" +
                                $" | Solddate: {searchPet.SoldDate} | Color: {searchPet.Color} | Previous owner: {searchPet.PrevOwner}" +
                                $" | Price: {searchPet.Price:N}");
                        }
                        Console.WriteLine("_______________________________________________________________________________________");
                        break;
                    case 3:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var birthDate = AskQuestion("Birthdate: ");
                        var soldDate = AskQuestion("Solddate: ");
                        var color = AskQuestion("Color: ");
                        var prevOwner = AskQuestion("Previous owner: ");
                        var price = AskQuestion("Price: ");
                        var pet = _petService.NewPet(name, type, Convert.ToDateTime(birthDate),
                                            Convert.ToDateTime(soldDate), color,
                                            prevOwner, Convert.ToDouble(price));
                        _petService.CreatePet(pet);
                        Console.WriteLine("_______________________________________________________________________________________");
                        break;
                    case 4:
                        var iDForDelete = PrintFindPetById();
                        _petService.DeletePet(iDForDelete);
                        Console.WriteLine("_______________________________________________________________________________________");
                        break;
                    case 5:
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine(petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newBirthDate = AskQuestion("Birthdate: ");
                        var newSoldDate = AskQuestion("Solddate: ");
                        var newColor = AskQuestion("Color: ");
                        var newPrevOwner = AskQuestion("Previous owner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdatePet(new Pet() {
                            Id = idForEdit,
                            Name = newName,
                            Type = newType,
                            Birthdate = Convert.ToDateTime(newBirthDate),
                            SoldDate = Convert.ToDateTime(newSoldDate),
                            Color = newColor,
                            PrevOwner = newPrevOwner,
                            Price = Convert.ToDouble(newPrice)
                        });
                        Console.WriteLine("_______________________________________________________________________________________");
                        break;
                    case 6:
                        Console.WriteLine("Sorting pet by price Cheap -> Expensive: ");
                        var sortResult = _petService.SortByPrice();
                        foreach (var sortPet in sortResult)
                        {                            
                            Console.WriteLine($"Name: {sortPet.Name} | Type: {sortPet.Type} | Birthdate: {sortPet.Birthdate}" +
                                $" | Solddate: {sortPet.SoldDate} | Color: {sortPet.Color} | Previous owner: {sortPet.PrevOwner}" +
                                $" | Price: {sortPet.Price:N}");
                        }
                        Console.WriteLine("_______________________________________________________________________________________");
                        break;
                    case 7:
                        Console.WriteLine("Showing 5 cheapest pets");
                        ShowCheapestPets();
                        Console.WriteLine("_______________________________________________________________________________________");
                        break;
                    default:
                        break;
                }
                valg = PetMenu(menuEnhender);
            }
            Console.WriteLine("Farvel");
            Console.ReadLine();
        }

        private void ShowCheapestPets()
        {
            var list = _petService.GetFiveCheapest();
            foreach (var pet in list)
            {
                Console.WriteLine($"Name: {pet.Name} | Type: {pet.Type} | Birthdate: {pet.Birthdate}" +
                                $" | Solddate: {pet.SoldDate} | Color: {pet.Color} | Previous owner: {pet.PrevOwner}" +
                                $" | Price: {pet.Price:N}");
            }
        }

        int PrintFindPetById()
        {
            Console.WriteLine("Skriv id på Pet ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID er altid et tal");
            }
            return id;
        }
        string PrintFintPetByType()
        {
            Console.WriteLine("Skriv type på Pet ");
            string type = Console.ReadLine();            
            return type;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void ShowPets(List<Pet> pets)
        {
            Console.WriteLine("\nListe af film");                                  
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} | Navn: {pet.Name} | Type: {pet.Type} " +
                    $"| Birthdate: {pet.Birthdate} | Solddate: {pet.SoldDate}" +
                    $" | Color: {pet.Color} | Previous Owner: {pet.PrevOwner} | Price: {pet.Price:N}");
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
