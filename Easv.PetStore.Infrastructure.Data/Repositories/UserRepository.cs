using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.PetStore.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly PetStoreAppContext _PSActx;

        public UserRepository(PetStoreAppContext petStoreAppContext)
        {
            _PSActx = petStoreAppContext;
        }

        //Create
        public void Add(User user)
        {
            var u = _PSActx.Users.Add(user).Entity;
            _PSActx.SaveChanges();
            //return u;
        }
        //Read
        public User Get(long id)
        {
            return _PSActx.Users.FirstOrDefault(u => u.Id == id);
        }
        //Read
        public IEnumerable<User> GetAll()
        {
            return _PSActx.Users.ToList();
        }
        //Update
        public void Edit(User user)
        {
            _PSActx.Entry(user).State = EntityState.Modified;
            _PSActx.SaveChanges();
            //return user;
        }        
        //Delete
        public void Remove(long id)
        {
            var item = _PSActx.Users.FirstOrDefault(u => u.Id == id);
            _PSActx.Users.Remove(item);
            _PSActx.SaveChanges();
            //return item;

        }
    }
}
