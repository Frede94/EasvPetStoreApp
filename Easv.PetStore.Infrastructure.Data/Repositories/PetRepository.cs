using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private PetStoreAppContext _PSActx;

        public PetRepository(PetStoreAppContext PSActx)
        {
            _PSActx = PSActx;
        }
         
        public Pet Create(Pet pet)
        {
            //if(pet.PetOwner != null)
            //{
            //    pet.PetOwner = _PSActx.Owners.FirstOrDefault
            //        (o => o.OwnerId == pet.PetOwner.OwnerId);
            //}
            //var p = _PSActx.Pets.Add(pet).Entity;
            //_PSActx.SaveChanges();
            _PSActx.Attach(pet).State = EntityState.Added;
            _PSActx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadAll(Filter filter)
        {
            //double price = 1000.00; //skal ændres til at man selv kan taste det
            if (filter == null)
            {
                return _PSActx.Pets;
            }
            return _PSActx.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
            
                //.Where(p => p.Price <= price)
                //.OrderBy(p => p.Price);
        }

        public Pet ReadById(int id)
        {
            return _PSActx.Pets
                .Include(p => p.PetOwner)
                .FirstOrDefault(p => p.Id == id);
            //return _PSActx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet ReadByIdIncludeOwner(int id)
        {
            return _PSActx.Pets
                .Include(p => p.PetOwner)
                .FirstOrDefault(p => p.Id == id);
            //return _PSActx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            //var pUpdate = _PSActx.Update(petUpdate).Entity;
            //var change = _PSActx.ChangeTracker.Entries();
            //_PSActx.Attach(pUpdate).State = EntityState.Added;
            _PSActx.Attach(petUpdate).State = EntityState.Modified;
            _PSActx.SaveChanges();
            return petUpdate;
            
        }

        public Pet delete(int id)
        {
            //var ownersToRemove = _PSActx.Pets
            //    .Where(p => p.PetOwner.OwnerId == id);
            //_PSActx.RemoveRange(ownersToRemove);
            var petsRemoved = _PSActx.Remove(new Pet { Id = id }).Entity;
            _PSActx.SaveChanges();
            return petsRemoved;
        }

        public int Count()
        {
            return _PSActx.Pets.Count();
        }
    }
}
