using CAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAM.WebUI.ViewModels
{
    public class DashboardSystems
    {
        public int Systems { get; set; }
        public int Servers { get; set; }
        public int Laptops { get; set; }
        public int Desktops { get; set; }
        public int Devices { get; set; }

        public List<Asset> Assets { get; set; }
    }
}
