using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PersonsAPI.Models;
using PersonsAPI.Models.Entity;
using PersonsAPI.Models.Repositories;

namespace PersonsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IMemoryCache _cache;
        private MemoryPersonRepository _personRepository;

        public PersonsController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _personRepository = new MemoryPersonRepository(memoryCache);
        }

        // GET persons
        [HttpGet]
        public ActionResult<string> Get(int skip, int take)
        {
            IList<Person> personList = _personRepository.GetAll(skip, take);
          return (JsonConvert.SerializeObject(personList, Formatting.Indented));
        }

        // GET persons/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Person person = _personRepository.GetPersonById(id);
            var jsonResponse = (JsonConvert.SerializeObject(person, Formatting.Indented));

            if (person == null)
            {
                return NotFound();
            }
            return jsonResponse;
        }


        // POST api/values
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            try
            {
               
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

              var newPerson = _personRepository.CreatePerson(person);

                return new CreatedResult(
                    new Uri("/api/Person", UriKind.Relative), person);
            }
            catch (Exception )
            {
               
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
