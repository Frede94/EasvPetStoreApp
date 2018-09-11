using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetStore.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public Owner NewOwner(string first_name, string last_name, string address, int pets)
        {
            var owner = new Owner
            {
                First_name = first_name,
                Last_name = last_name,
                Pets = new Pet
                {
                    //Something...
                },
                Adress = address
            };
            return owner;
        }

        public Owner CreatOwner(Owner o)
        {
            return _ownerRepo.Create(o);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public List<Owner> FindOwnerByName(string searchValue)
        {
            var list = _ownerRepo.ReadAll();
            var queryCont = list.Where(owner => owner.First_name.Equals(searchValue));
            queryCont.OrderBy(owner => owner.First_name);
            return queryCont.ToList();
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public List<Owner> SortOwnerByNumberOfPets()
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById(ownerUpdate.OwnerId);

            owner.First_name = ownerUpdate.First_name;
            owner.Last_name = ownerUpdate.Last_name;
            owner.Adress = ownerUpdate.Adress;
            owner.Pets = ownerUpdate.Pets;

            return owner;
        }

        public Owner Delete(int IdForDelete)
        {
            if (IdForDelete < 1)
            {
                throw new InvalidOperationException("Forkert!");
            }
            return _ownerRepo.delete(IdForDelete);
        }
    }
}
