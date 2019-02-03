using Microsoft.Extensions.Caching.Memory;
using PersonsAPI.Models.Entity;
using PersonsAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsAPI.Models.Services
{
    public class PersonCacheService
    {
        public IList<Person> _items { get; set; }
        private const string _cacheKey = "cache-key";

        private readonly IMemoryCache _cache;


        public PersonCacheService(IMemoryCache cache)
        {
            _cache = cache;

        }

        public IList<Person> GetPersons()
        {
            
            if (_cache.TryGetValue(_cacheKey, out IList<Person> persons))
            {
                return persons;
            }

            _cache.Set(_cacheKey, fillPersons());
            if (_cache.TryGetValue(_cacheKey, out IList<Person> personsCached))
            {
                return personsCached;
            }

            return persons;

        }

        public List<Person> fillPersons()
        {
           
           var persons = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                var basePerson = new Person()
                {
                    Id = i,
                    FistName = "Roberto",
                    LastName = "Flores",
                    Disabled = ((i & 1) == 0)
                };

                persons.Add(basePerson);
            }
            return persons;
        }
    }
}
