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
        private PetStoreAppContext _PSActx;

        public OwnerRepository(PetStoreAppContext PSActx)
        {
            _PSActx = PSActx;
        }

        public Owner Create(Owner owner)
        {
            var o = _PSActx.Owners.Add(owner).Entity;
            _PSActx.SaveChanges();
            return o;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _PSActx.Owners;
        }

        public Owner ReadById(int id)
        {
            return _PSActx.Owners.FirstOrDefault(o => o.OwnerId == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }

        public Owner delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
