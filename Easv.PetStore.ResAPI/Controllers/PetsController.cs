using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetStore.ResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
    // GET api/values
    [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.FindPetById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("Please remember a name!");
            }
            if (pet.Price < 0)
            {
                return BadRequest("Pet mangler en pris");
            }
            if (string.IsNullOrEmpty(pet.Color))
            {
                return BadRequest("Pet mangler en farve");
            }
            if (string.IsNullOrEmpty(pet.PrevOwner))
            {
                return BadRequest("Pet mangler en PrevOwner");
            }
            return _petService.CreatePet(pet);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id < 1 || id != pet.Id)
            {
                return BadRequest("ID passer ikke men ID på pet");
            }
            
            return Ok(_petService.UpdatePet(pet));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            Pet pet = _petService.DeletePet(id);
            if (pet == null)
            {
                return StatusCode(404, "Kunne ikke finde pet med id:" + id);
            }
            return Ok($"Pet with Id: {id} is Deleted");
        }
    }
}
