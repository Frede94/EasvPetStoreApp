using Easv.PetStore.Core.Entity;
using System.Collections.Generic;

namespace Easv.PetStore.Core.DomainService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadById(int id);

        IEnumerable<Pet> ReadAll(Filter filter = null);

        Pet Update(Pet petUpdate);

        Pet delete(int id);
        int Count();
    }
}
