using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner Create(Owner owner)
        {
            owner.OwnerId = FakeDB.ownerId++;
            var owners = FakeDB.Owners.ToList();
            owners.Add(owner);
            FakeDB.Owners = owners;
            return owner;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return FakeDB.Owners;
        }

        public Owner ReadById(int id)
        {
            foreach (var owner in FakeDB.Owners)
            {
                if (owner.OwnerId == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFraDB = this.ReadById(ownerUpdate.OwnerId);
            if(ownerFraDB != null)
            {
                ownerFraDB.First_name = ownerUpdate.First_name;
                ownerFraDB.Last_name = ownerUpdate.Last_name;
                ownerFraDB.Adress = ownerUpdate.Adress;
                //ownerFraDB.Pets = ownerUpdate.Pets;
                return ownerFraDB;
            }
            return null;
        }

        public Owner delete(int id)
        {
            var owners = FakeDB.Owners.ToList();
            var ownersToDelete = owners.FirstOrDefault(owner => owner.OwnerId == id);
            owners.Remove(ownersToDelete);
            FakeDB.Owners = owners;
            return ownersToDelete;
        }
    }
}
