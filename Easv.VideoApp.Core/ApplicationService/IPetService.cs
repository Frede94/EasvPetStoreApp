using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string prevOwner, double price);
        //Create
        Pet CreatePet(Pet p);
        //Read
        Pet FindPetById(int id);

        List<Pet> FindPetByType(string searchValue);

        List<Pet> SortByPrice();

        List<Pet> GetFiveCheapest();

        List<Pet> GetAllPets();
        //Update
        Pet UpdatePet(Pet petUpdate);
        //Delete
        Pet DeletePet(int iDForDelete);
    }
}
