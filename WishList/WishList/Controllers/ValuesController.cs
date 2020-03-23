using Newtonsoft.Json;
using SecretSanta.Services.WishService;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WishList.Controllers.Api
{
    public class ValuesController : ApiController
    {
        private IWishService _wishService;
        public ValuesController(IWishService wishService)
        {
            _wishService = wishService;
        }
        // GET: api/Profile
        [HttpGet, Route("api/ChangeStatus/{id}")]
        public IHttpActionResult Get(long id)
        {
            var isComplete = _wishService.ChangeStatus(id);
           
            return Ok(isComplete);
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
