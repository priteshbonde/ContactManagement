using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagementAPI.Controllers
{
    public class ContactController : ApiController
    {
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Contact/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        [HttpPut]
        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpDelete]
        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
