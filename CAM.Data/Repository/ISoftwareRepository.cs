using CAM.Entities;
using System.Collections.Generic;

namespace CAM.Data.Repository
{
    public interface ISoftwareRepository
    {
        void Create(Software software);
        IEnumerable<Software> Read();
    }
}
