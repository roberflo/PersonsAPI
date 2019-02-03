using System;
using System.Collections.Generic;
using System.Linq;
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
            return (JsonConvert.SerializeObject(person, Formatting.Indented));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
