using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;

namespace Easv.PetStore.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IOwnerService _ownerRepo;
        readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository, IOwnerService ownerService)
        {
            _ownerRepo = ownerService;
            _petRepo = petRepository;
        }

        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string prevOwner, double price)
        {
            var pet = new Pet
            {
                Name = name,
                Type = type,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PrevOwner = prevOwner,
                Price = price
            };
            return pet;
        }
        //Create
        public Pet CreatePet(Pet p)
        {
            return _petRepo.Create(p);
        }
        //Read
        public List<Pet> GetAllPets()
        {
            //var list = _petRepo.ReadAll().ToList();
            //foreach (var pet in list)
            //{
            //    pet.PetOwner = _ownerRepo.FindOwnerById(pet.Id);
            //}
            return _petRepo.ReadAll().ToList();
        }
        //Read
        public Pet FindPetById(int id)
        {
            var pet = _petRepo.ReadById(id);
            pet.PetOwner = _ownerRepo.FindOwnerById(pet.PetOwner.OwnerId);
            return pet;
            //return _petRepo.ReadById(id);
        }
        //Read
        public List<Pet> FindPetByType(string searchValue)
        {
            var list = _petRepo.ReadAll();
            var queryCont = list.Where(pet => pet.Type.Equals(searchValue));
            queryCont.OrderBy(pet => pet.Type);
            return queryCont.ToList();
        }
        //Read
        public List<Pet> SortByPrice()
        {
            var list = _petRepo.ReadAll();
            var query = list.OrderBy(pet => pet.Price);
            return query.ToList();
        }
        //Read
        public List<Pet> GetFiveCheapest()
        {
            var listQuery= _petRepo.ReadAll();
            var query = listQuery.OrderBy(pet => pet.Price);            
            return query.Take(5).ToList();
        }
        //update
        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);

            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.Birthdate = petUpdate.Birthdate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.PrevOwner = petUpdate.PrevOwner;
            pet.Price = petUpdate.Price;

            return pet;
        }
        //Delete
        public Pet DeletePet(int iDForDelete)
        {
            if (iDForDelete < 1)
            {
                throw new InvalidOperationException("Eyy day is not an id on da list!");
            }
            return _petRepo.delete(iDForDelete);
            //return _petRepo.delete(iDForDelete);
        }

        
    }
}
