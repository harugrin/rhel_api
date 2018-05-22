using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RHELApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly Dictionary<int, string> data;

        public ValuesController()
        {
            data = new Dictionary<int, string>();
            data.Add(1, "Simple test for RHEL 7 x64 container use.");
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = data.FirstOrDefault(d => d.Key.Equals(id)).Value;

            if (string.IsNullOrEmpty(result))
                return new NotFoundObjectResult($"No match for ID: \"{id}\"!");

            return new OkObjectResult(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return new StatusCodeResult(403);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return new StatusCodeResult(403);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new StatusCodeResult(403);
        }
    }
}
