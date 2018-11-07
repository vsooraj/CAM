using CAM.Entities;
using System.Collections.Generic;
namespace CAM.Webservice.Services
{
    public interface ISoftwareService
    {
        IEnumerable<Software> Read();
    }
}