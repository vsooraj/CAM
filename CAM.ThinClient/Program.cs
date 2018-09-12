using CAM.Entities;
using Newtonsoft.Json;
using System;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace CAM.ThinClient
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InstalledApps();
            Console.ReadKey();
        }
       
        static Software Create(Software model)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51855");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsJsonAsync("/api/Softwares", model).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Software data = JsonConvert.DeserializeObject<Software>(stringData);
                return data;
            }
        }
        private static void InstalledApps()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            int index = 1;
            var systemInfo = new SystemInfo();
            systemInfo.Host = getSystemInfo().Split("|")[0].ToString();
            systemInfo.IP = getSystemInfo().Split("|")[2].ToString();
           
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine(" " + index + " Software  " + mo["Name"]);
                index++;
                Create(new Software { Id = index, Name = (string)mo["Name"], InstallDate = DateTime.Now.ToShortDateString(), SystemInfo=systemInfo });
            }
        }
        private static string getSystemInfo()
        {

            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            //Console.WriteLine("Local Machine's Host Name: " + strHostName);
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            //for (int i = 0; i < addr.Length; i++)
            //{
            //    Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
            //}
            //MAC | IP Address
            return strHostName+"|" + addr[0].ToString()+"|"+addr[1].ToString();
        }
    }
}

