using CAM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAM.Service.ViewModels
{
    public class HomeViewModel
    {
        public List<Software> Softwares { get; set; }
        public string Title { get; set; }

    }
}
