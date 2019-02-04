using PersonsAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsAPI.Models.Repositories.Interfaces
{
   public interface IPersonRepository
    {
        IList<Person> GetAll(int skip, int take);
        Person GetPersonById(int id);
        Person CreatePerson(Person person);
        void UpdatePerson(int id, Person person);
        void DeletePerson(int id);
    }
}
