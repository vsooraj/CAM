﻿namespace CAM.Entities
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Publisher { get; set; }
        public string InstallDate { get; set; }
        public string InstallLocation { get; set; }
        
        public SystemInfo SystemInfo { get; set; }
    }
}
