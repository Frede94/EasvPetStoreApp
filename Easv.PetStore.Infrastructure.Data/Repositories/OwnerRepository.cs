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

        public IEnumerable<Owner> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return _PSActx.Owners;
            }
            return _PSActx.Owners.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);
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

            //var oUpdate = _PSActx.Update(ownerUpdate).Entity;
            //var change = _PSActx.ChangeTracker.Entries();
            //_PSActx.Attach(oUpdate).State = EntityState.Added;
            //return oUpdate;
            _PSActx.Attach(ownerUpdate).State = EntityState.Modified;
            _PSActx.SaveChanges();
            return ownerUpdate;
        }

        public Owner delete(int id)
        {
            var ownersRemoved = _PSActx
                .Remove(new Owner { OwnerId = id }).Entity;
            _PSActx.SaveChanges();
            return ownersRemoved;
        }

    }
}
