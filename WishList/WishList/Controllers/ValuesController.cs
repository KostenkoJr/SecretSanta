using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WishList.Controllers.Api
{
    public class ValuesController : ApiController
    {
        // GET: api/Profile
        [HttpGet, Route("api/FullWorkflow")]
        public IHttpActionResult Get()
        {
            var arr = new string[] { "value1", "value2" };
            var s = JsonConvert.SerializeObject(arr);
            return Ok(s);
        }

        // GET: api/Profile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Profile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
