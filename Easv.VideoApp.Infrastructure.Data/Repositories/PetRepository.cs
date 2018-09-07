using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Easv.PetStore.Infrastructure.Data.Repositories
{

    public class PetRepository : IPetRepository
    {
        public Pet Create(Pet pet)
        {
            pet.Id = FakeDB.petId++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in FakeDB.Pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;            
        }
        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.Pets;
        }

        public Pet Update(Pet petUpdate)
        {
            var petFraDB = this.ReadById(petUpdate.Id);
            if (petFraDB != null)
            {
                petFraDB.Name = petUpdate.Name;
                petFraDB.Type = petUpdate.Type;
                petFraDB.Birthdate = petUpdate.Birthdate;
                petFraDB.SoldDate = petUpdate.Birthdate;
                petFraDB.Color = petUpdate.Color;
                petFraDB.PrevOwner = petUpdate.PrevOwner;
                petFraDB.Price = petUpdate.Price;
                return petFraDB;
            }
            return null;
        }

        public Pet delete(int id)
        {
            var pets = FakeDB.Pets.ToList();
            var petsToDelete = pets.FirstOrDefault(pet => pet.Id == id);
            pets.Remove(petsToDelete);
            FakeDB.Pets = pets;
            return petsToDelete;
        }
    }
}
