using CAM.Entities;
using System.Linq;

namespace CAM.Win.Repositories
{
    interface ISoftwareRepository
    {

        IQueryable<Software> GetAll();

        void Add(Software entity);

    }
}
