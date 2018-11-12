using Easv.PetStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.PetStore.Core.DomainService
{
    public interface IUserRepository<User>
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        void Add(User user);
        void Edit(User user);
        void Remove(long id);
    }
}
