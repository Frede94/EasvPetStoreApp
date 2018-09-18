using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
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
            var p = _PSActx.Pets.Add(pet).Entity;
            _PSActx.SaveChanges();
            return p;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _PSActx.Pets;
        }

        public Pet ReadById(int id)
        {
            return _PSActx.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            var pUpdate = _PSActx.Update(petUpdate).Entity;
            var change = _PSActx.ChangeTracker.Entries();
            _PSActx.SaveChanges();
            return pUpdate;
        }

        public Pet delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
