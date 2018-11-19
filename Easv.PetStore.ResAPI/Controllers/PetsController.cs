using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easv.PetStore.ResAPI.Controllers
{
    [Produces("application/json")]
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
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage != 0 && filter.ItemsPrPage != 0)
                {
                    return Ok(_petService.GetFilteredPets(filter));
                }
                else
                {
                    return Ok(_petService.GetAllPets());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }                                   
        }

        // GET api/values/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id skal være over 0");
            }
            return Ok(_petService.FindPetById(id));
        }

        // POST api/values
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
