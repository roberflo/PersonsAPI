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
        public PersonCacheService cacheService { get; set; }
        public MemoryPersonRepository(IMemoryCache cache)
        {
            cacheService = new PersonCacheService(cache);
            personList = cacheService.GetPersons();
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

        public Person GetPersonById(int id)
        {
            
            try
            {
                return personList.First(person => person.Id == id);
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
             
        }

        public Person CreatePerson(Person person)
        {
            try
            {
                //Reasign id
                person.Id = personList.Count;
                personList.Add(person);
                cacheService.UpdatePersonsCache(personList);
            }
            catch (Exception e)
            {

                throw e;
            }
            return person;
            
        }

        public void UpdatePerson(int id, Person person)
        {
            try
            {

                var matchPerson = personList.FirstOrDefault(p => p.Id == id);
                matchPerson.FistName = person.FistName;
                matchPerson.LastName = person.LastName;
                matchPerson.Disabled = person.Disabled;

                cacheService.UpdatePersonsCache(personList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
