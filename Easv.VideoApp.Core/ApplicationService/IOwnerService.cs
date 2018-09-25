using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.ApplicationService
{
    public interface IOwnerService
    {
        //Create
        Owner NewOwner(string first_name, string last_name, string address, int pets);
        Owner CreatOwner(Owner o);
        //Read
        Owner FindOwnerById(int id);
        List<Owner> FindOwnerByName(string searchValue);
        List<Owner> SortOwnerByNumberOfPets();
        List<Owner> GetAllOwners();
        List<Owner> GetFilteredOwners(Filter filter);
        //Update
        Owner UpdateOwner(Owner ownerUpdate);
        //Delete
        Owner Delete(int IdForDelete);
        
    }
}
