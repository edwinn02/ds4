using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalculadoraAPI.Controllers
{
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            
            var values = new List<string> { "value1", "value2" };
            return values;
        }

        public string Get(int id = 0) 
        {
            return $"value";  
        }


        public void Post([FromBody] string value)
        {
        }

        
        public void Put(int id, [FromBody] string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
