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
        User Add(User user);
        User Edit(User user);
        User Remove(long id);
    }
}
