using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Warehouse.Controllers
{
    [Produces("application/json")]
    [Route("api/Parts")]
    public class PartsController : Controller
    {
        public PartsController()
        {
            

        }


        // GET: api/Parts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };


        }

        // GET: api/Parts/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Parts
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Parts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
