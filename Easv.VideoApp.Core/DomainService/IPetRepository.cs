using Easv.PetStore.Core.Entity;
using System.Collections.Generic;

namespace Easv.PetStore.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadById(int id);

        IEnumerable<Pet> ReadAll();

        Pet Update(Pet petUpdate);

        void delete(int id);
    }
}
