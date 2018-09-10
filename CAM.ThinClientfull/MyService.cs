using CAM.Entities;
using Newtonsoft.Json;
using System;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace CAM.ThinClientfull
{
    public class MyService
    {
        HttpClient client = new HttpClient();
        public void Start()
        {
            // write code here that runs when the Windows Service starts up.  
            Timer myTimer = new Timer(OnTimerEvent, null, 0, 5000);

        }

        private void OnTimerEvent(object state)
        {
            InstalledApps();
        }

        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
        }
        private void InstalledApps()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            int index = 1;
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine(" " + index + " Software  " + mo["Name"]);
                index++;
                Create(new Software { Id = index, Name = (string)mo["Name"], InstallDate = DateTime.Now.ToShortDateString(), IP = getSystemInfo() });
            }
        }

        private Software Create(Software model)
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

        private string getSystemInfo()
        {

            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            //Console.WriteLine("Local Machine's Host Name: " + strHostName);
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[0].ToString();
        }
        //private Software Create(Software model)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:51855");
        //        MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
        //        client.DefaultRequestHeaders.Accept.Add(contentType);
        //        HttpResponseMessage response = client.PostAsJsonAsync("/api/Softwares", model).Result;
        //        string stringData = response.Content.ReadAsStringAsync().Result;
        //        Software software = JsonConvert.DeserializeObject<Software>(stringData);
        //        return software;
        //    }
        // }
    }
}
