using CAM.Entities;
using System;
using System.Management;
using System.Text;

namespace CAM.Win.Services
{
    public class SystemService
    {
        public SystemInfo Retrieve()
        {
            string query = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'";

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearch.Get();
            var host = string.Empty;
            var ipaddresses = new StringBuilder();
            var defaultgateway = string.Empty;
            var subnet = string.Empty;
            foreach (ManagementObject mo in moCollection)
            {
                Console.WriteLine("HostName = " + mo["DNSHostName"]);
                Console.WriteLine("Description = " + mo["Description"]);
                host = mo["DNSHostName"]?.ToString() ?? "Host not found";

                string[] addresses = (string[])mo["IPAddress"];
                foreach (string ipaddress in addresses)
                {
                    Console.WriteLine("IPAddress = " + ipaddress);
                    ipaddresses.Append(ipaddresses.Length != 0 ? (" | " + ipaddress) : ipaddress);

                }

                #region Subnet & IPGateway
                //string[] subnets = (string[])mo["IPSubnet"];
                //foreach (string ipsubnet in subnets)
                //{
                //    Console.WriteLine("IPSubnet = " + ipsubnet);
                //}


                //string[] defaultgateways = (string[])mo["DefaultIPGateway"];
                //foreach (string defaultipgateway in defaultgateways)
                //{
                //    Console.WriteLine("DefaultIPGateway = " + defaultipgateway);
                //} 
                #endregion
            }

            return new SystemInfo() { Host = host, IP = ipaddresses.ToString() };

        }

    }
}
