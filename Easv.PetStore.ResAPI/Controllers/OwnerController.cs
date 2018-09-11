using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetStore.ResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Owner> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id skal være mere en 0");
            }
            return _ownerService.FindOwnerById(id);
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.First_name))
            {
                return BadRequest("Please remember a name!");
            }
            if (string.IsNullOrEmpty(owner.Last_name))
            {
                return BadRequest("Please remember a last name");
            }
            if (string.IsNullOrEmpty(owner.Adress))
            {
                return BadRequest("Remember the adress");
            }
            return _ownerService.CreatOwner(owner);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.OwnerId)
            {
                return BadRequest("ID passer ikke emd id på owner");
            }
            return Ok(_ownerService.UpdateOwner(owner));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Owner owner = _ownerService.Delete(id);
            if (owner == null)
            {
                return StatusCode(404, "Kunne ikke finde pet id: " + id);
            }
            return Ok($"Owner med Id: {id} is deleted");
        }
    }
}
