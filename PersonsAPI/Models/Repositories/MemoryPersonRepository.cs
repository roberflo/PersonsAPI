using Microsoft.Extensions.Caching.Memory;
using PersonsAPI.Models.Entity;
using PersonsAPI.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsAPI.Models.Repositories
{
    public class MemoryPersonRepository 
    {
        public IList<Person> personList { get; set; }
        public MemoryPersonRepository(IMemoryCache cache)
        {

            personList = new PersonCacheService(cache).GetPersons();
        }

        public IList<Person> GetAll(int skip, int take)
        {
            IList<Person> response;
            if(skip > 0 || take > 0)
            {
                response = personList.AsQueryable().Skip(skip).Take(take).ToList();
            }
            else
            {
                response = personList;
            }
            return response;
          
        }
    }
}
