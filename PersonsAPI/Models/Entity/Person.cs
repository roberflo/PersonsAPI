using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsAPI.Models.Entity
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("first")]
        public string FistName { get; set; }
        
        [JsonProperty("last")]
        public string LastName { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        public bool ShouldSerializeDisabled()
        {
            // don't serialize the disabled if false
            return (Disabled);
        }


    }
}
