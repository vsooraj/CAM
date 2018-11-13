using CAM.Entities;
using CAM.Webservice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CAM.Webservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        private readonly ISoftwareService _softwareService;

        public SoftwaresController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }
        // GET: api/Softwares
        [HttpGet]
        public IEnumerable<Software> Get()
        {
            var softwares = _softwareService.Read();
            return softwares;
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
            _softwareService.Create(model);
        }

        // PUT: api/Softwares/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
