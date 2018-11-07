using CAM.Data.Repository;
using CAM.Entities;
using System.Collections.Generic;
namespace CAM.Webservice.Services
{
    public class SoftwareService : ISoftwareService
    {
        private readonly ISoftwareRepository _softwareRepository;

        public SoftwareService(ISoftwareRepository softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }

        public IEnumerable<Software> Read()
        {
            var softwares = _softwareRepository.Read();
            return softwares;
        }
    }
}
