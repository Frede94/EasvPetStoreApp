using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetStore.ResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository<User> repository;

        public UserController(IUserRepository<User> repos)
        {
            repository = repos;
        }
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return Ok(repository.GetAll());
        }

        //// GET: api/User/5
        //[HttpGet("{id}")]
        //public ActionResult<User> Get(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest("Id skal være over 0");
        //    }
        //    return Ok(repository.);
        //}

        // POST: api/User
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return repository.Add(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            return Ok(repository.Edit(user));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            User user = repository.Remove(id);
            return Ok($"User with id: {id} is Deleted");
        }
    }
}
