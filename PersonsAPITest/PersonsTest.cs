using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PersonsAPI.Models;
using PersonsAPI.Models.Entity;
using PersonsAPI.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using Person = PersonsAPI.Models.Entity.Person;

namespace PersonsAPITest
{
    [TestClass]
    public class PersonsTest
    {

        //Needed :  AspNetCore.JsonPatch, install from nugget
        [TestMethod]
        public void GivenPersonWhenShowThenShowConventionOfNoDisabledWhenFalse()
        {
            //Arrange
            Person demo = new Person()
            {
                Id = 1,
                FistName = ".Net",
                LastName = "Developer",
                Disabled = true
            };
            bool disabledFound = false;

            //ACT
            string json = JsonConvert.SerializeObject(demo, Newtonsoft.Json.Formatting.Indented);
            var obj = JsonConvert.DeserializeObject(json);

            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                if ("disabled" == pi.Name)
                {
                    disabledFound = true;
                } 
            }
            Assert.IsNotNull(json);
            Assert.IsFalse(disabledFound);
        }

        [TestMethod]
        public void GivenPersonWhenGetAllbyPaginationThenShowCorrectPage()
        {
            //Arrange
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

            //ACT
            var result = persons.AsQueryable().Skip(0).Take(5).ToList();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result[0].Id, 0);
            Assert.AreEqual(result[4].Id, 4);
        }

        //No nsustitute on core2, search for another mocking tool
        [TestMethod]
        public void GivenPersonWhenGetByIdThenShowCorrectPerson()
        {
            //Arrange
            var persons = new List<Person>();

            for (int i = 0; i < 3; i++)
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

            //ACT
            var result = persons.First(person => person.Id == 2);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 2);
            
        }



    }
}
