using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
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
            return _PSActx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.OwnerId == id);
            //return _PSActx.Owners.FirstOrDefault(o => o.OwnerId == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            var oUpdate = _PSActx.Update(ownerUpdate).Entity;
            var change = _PSActx.ChangeTracker.Entries();
            _PSActx.SaveChanges();
            return oUpdate;
        }

        public Owner delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
