using CAM.Entities;
using System;
using System.Collections.Generic;
using System.Management;
using System.Net;

namespace CAM.Win
{
    internal class SoftwareRepository
    {
        List<Software> softwareList;
        public IEnumerable<Software> Read(EnvironmentType type)
        {

            if (EnvironmentType.Testing == type)
            {
                softwareList = new List<Software>() {

                    new Software() {Id=1,Name="", Publisher="Microsoft",Vendor="",SystemInfo=new SystemInfo{ Host="CBT-001-LT-WS",IP="192.168.1.1"} , InstalledDate="2018-01-01"},
                    new Software() {Id=2,Name="", Publisher="Microsoft",Vendor="",SystemInfo=new SystemInfo{ Host="CBT-001-LT-WS",IP="192.168.1.1"} , InstalledDate="2018-01-01"},
                    new Software() {Id=3,Name="", Publisher="Microsoft",Vendor="",SystemInfo=new SystemInfo{ Host="CBT-001-LT-WS",IP="192.168.1.1"} , InstalledDate="2018-01-01"},
                    new Software() {Id=4,Name="", Publisher="Microsoft",Vendor="",SystemInfo=new SystemInfo{ Host="CBT-001-LT-WS",IP="192.168.1.1"} , InstalledDate="2018-01-01"},
                    new Software() {Id=5,Name="", Publisher="Microsoft",Vendor="",SystemInfo=new SystemInfo{ Host="CBT-001-LT-WS",IP="192.168.1.1"} , InstalledDate="2018-01-01"}
                };
            }
            else if (EnvironmentType.Developement == type)
            {
                InstalledApps();
            }
            return softwareList;

        }

        public enum EnvironmentType
        {
            Developement,
            Production,
            Testing

        }
        private List<Software> InstalledApps()
        {
            SystemInfo systemInfo = new SystemInfo() { Host = getSystemInfo()[0], IP = getSystemInfo()[1] };
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            int index = 1;

            foreach (ManagementObject mo in mos.Get())
            {
                index++;
                if (!string.IsNullOrEmpty(mo["Name"].ToString()))
                {
                    softwareList.Add(new Software
                    {
                        Id = index,
                        Name = (string)mo["Name"],
                        InstalledDate = DateTime.Now.ToShortDateString(),
                        Size = "",
                        Publisher = "",
                        InstallLocation = "",
                        Version = "",
                        CreatedOn = "",
                        Vendor = "",
                        SystemInfo = systemInfo
                    }
                    );
                }
            }
            return softwareList;
        }

        private string[] getSystemInfo()
        {
            var strArray = new string[2];

            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            strArray[0] = addr[0].ToString();
            strArray[1] = addr[1].ToString();
            return strArray;
        }
    }
}