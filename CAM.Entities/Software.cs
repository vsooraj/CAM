namespace CAM.Entities
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Publisher { get; set; }
        public string InstalledDate { get; set; }
        public string InstallLocation { get; set; }
        public string Version { get; set; }
        public string CreatedOn { get; set; }
        public string Vendor { get; set; }

        public SystemInfo SystemInfo { get; set; }
    }
}
