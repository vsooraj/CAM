using CAM.Entities;
using Newtonsoft.Json;
using System;
using System.Globalization;
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
                client.BaseAddress = new Uri("https://camservice20180912011628.azurewebsites.net/");
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
            #region ManagementObject
            //ManagementObject
            //dr["Name"]              = MO["Name"].ToString();
            //dr["AssignmentType"]    = MO["AssignmentType"].ToString();
            //dr["Caption"]           = MO["Caption"];
            //dr["Description"]       = MO["Description"];
            //dr["IdentifyingNumber"] = MO["IdentifyingNumber"];
            //dr["InstallLocation"]   = MO["InstallLocation"];
            //var newDate = DateTime.ParseExact(MO["InstallDate"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            //dr["Instal Date"] = newDate;
            //dr["InstallState"]      = MO["InstallState"];
            //dr["HelpLink"]          = MO["HelpLink"];
            //dr["HelpTelephone"]     = MO["HelpTelephone"];
            //dr["InstallSource"]     = MO["InstallSource"];
            //dr["Language"]          = MO["Language"];
            //dr["LocalPackage"]      = MO["LocalPackage"];
            //dr["PackageCache"]      = MO["PackageCache"];
            //dr["PackageCode"]       = MO["PackageCode"];
            //dr["PackageName"]       = MO["PackageName"];
            //dr["InstallState"]      = MO["InstallState"];
            //dr["ProductID"]         = MO["ProductID"];
            //dr["RegOwner"]          = MO["RegOwner"];
            //dr["RegCompany"]        = MO["RegCompany"];
            //dr["SKUNumber"]         = MO["SKUNumber"];
            //dr["Transforms"]        = MO["Transforms"];
            //dr["URLInfoAbout"]      = MO["URLInfoAbout"];
            //dr["URLUpdateInfo"]     = MO["URLUpdateInfo"];
            //dr["Vendor"]            = MO["Vendor"];
            //dr["WordCount"]         = MO["WordCount"];
            //dr["Version"]           = MO["Version"];

            #endregion

            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            int index = 1;
            var installDate = DateTime.Now;
            var systemInfo = new SystemInfo();
            systemInfo.Host = getSystemInfo().Split("|")[0].ToString();
            systemInfo.IP = getSystemInfo().Split("|")[2].ToString();
           
            foreach (ManagementObject mo in mos.Get())
            {
                Console.WriteLine(" " + index + " Software  " + mo["Name"] + " InstallDate  " + mo["InstallDate"] + " Version  " + mo["Version"] + " Vendor  " + mo["Vendor"]);
                index++;
                installDate = DateTime.ParseExact(mo["InstallDate"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
               
                Create(new Software { Id = index, Name = (string)mo["Name"], InstallDate = installDate.ToString(), SystemInfo=systemInfo,Version= (string)mo["Version"], Vendor = (string)mo["Vendor"] });
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

