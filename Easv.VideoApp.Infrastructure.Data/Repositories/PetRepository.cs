using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using System.Collections.Generic;

namespace Easv.PetStore.Infrastructure.Data.Repositories
{

    public class PetRepository : IPetRepository
    {
        static int id = 1;
        private List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet video)
        {
            video.Id = id++;
            _pets.Add(video);
            return video;
        }

        public Pet ReadById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;            
        }
        public List<Pet> ReadAll()
        {
            return _pets;
        }

        //ID: int
        //Name: string
        //Type: string or Enum
        //Birthdate: DateTime
        //SoldDate: DateTime
        //Color: string
        //PreviousOwner: string
        //Price: double
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
            var petFundet = this.ReadById(id);

            if (petFundet != null)
            {
                _pets.Remove(petFundet);
                return petFundet;
            }
            return null;
        }
    }
}
