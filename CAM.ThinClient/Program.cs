using CAM.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
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
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var mySettingsConfig = new MySettingsConfig();
            configuration.GetSection("MySettings").Bind(mySettingsConfig);

            //Console.WriteLine("Hello World!");
            //Console.WriteLine("Setting from appsettings.json: " + mySettingsConfig.AccountName);
            //Console.WriteLine("Setting from secrets.json: " + mySettingsConfig.ApiSecret);
            //Console.WriteLine("Setting from appsettings.json URL: " + mySettingsConfig.ApiURL);
            //Console.WriteLine("Connection string: " + configuration.GetConnectionString("DefaultConnection"));
            InstalledApps(mySettingsConfig);
            Console.ReadKey();
        }
       
       
        private static void InstalledApps(MySettingsConfig mySettingsConfig)
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

            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
                int index = 1;
                var installDate = DateTime.Now;
                var name = "";
                var systemInfo = new SystemInfo();
                systemInfo.Host = getSystemInfo().Split("|")[0].ToString();
                systemInfo.IP = getSystemInfo().Split("|")[2].ToString();

                foreach (ManagementObject mo in mos.Get())
                {
                    if (mo["Name"] != null)
                    {
                        installDate = DateTime.ParseExact(mo["InstallDate"].ToString() ?? "1900/01/01", "yyyyMMdd", CultureInfo.InvariantCulture);
                        name = mo["Name"].ToString() ?? "Name not avail";
                        var Version = mo["Version"].ToString() ?? "Version not avail";
                        var Vendor = mo["Vendor"].ToString() ?? "Vendor not avail";
                        //Console.WriteLine(" " + index + " Software  " + name + " InstallDate  " + installDate + " Version  " + Version + " Vendor  " + Vendor);
                        index++;
                        Create(new Software { Id = index, Name = name,InstallDate= installDate.ToString(), SystemInfo = systemInfo, Version = Version, Vendor = Vendor }, mySettingsConfig.ApiURL);
                    }
                }
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }
        static Software Create(Software model, string url)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsJsonAsync("/api/Softwares", model).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Software data = JsonConvert.DeserializeObject<Software>(stringData);
                return data;
            }
        }
        private static string getSystemInfo()
        {
            String strHostName = string.Empty;
            // Getting Ip address of local machine... First get the host name of local machine.
            strHostName = Dns.GetHostName();
            //Console.WriteLine("Local Machine's Host Name: " + strHostName);           // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return strHostName+"|" + addr[0].ToString()+"|"+addr[1].ToString();
        }
    }
}

