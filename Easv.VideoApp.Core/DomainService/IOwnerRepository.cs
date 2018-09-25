using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);

        Owner ReadById(int id);

        IEnumerable<Owner> ReadAll(Filter filter = null);

        Owner Update(Owner ownerUpdate);

        Owner delete(int id);
    }
}
