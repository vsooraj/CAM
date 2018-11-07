using CAM.Data.Repository;
using CAM.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CAM.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Softwares")]
    public class SoftwaresController : Controller
    {
        private readonly ISoftwareRepository _softwareRepository;

        public SoftwaresController(ISoftwareRepository softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }
        // GET: api/Softwares
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Softwares/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Softwares
        [HttpPost]
        public void Post([FromBody]Software model)
        {
            _softwareRepository.Create(model);
        }

        // PUT: api/Softwares/5
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
