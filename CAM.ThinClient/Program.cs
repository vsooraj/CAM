using CAM.Entities;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace CAM.ThinClient
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            InstalledApps();
            //GetInstalledApps();
            Console.ReadKey();
        }
        public static void GetInstalledApps()

        {
            #region MyRegion
            //ManagementObjectCollection moReturn;
            //ManagementObjectSearcher moSearch;
            //moSearch = new ManagementObjectSearcher("Select * from Win32_Product");
            //Value / Windows Installer property
            //DisplayName ==> ProductName property
            //DisplayVersion ==> Derived from ProductVersion property
            //Publisher ==> Manufacturer property
            //VersionMinor ==> Derived from ProductVersion property
            //VersionMajor ==> Derived from ProductVersion property
            //Version ==> Derived from ProductVersion property
            //HelpLink ==> ARPHELPLINK property
            //HelpTelephone ==> ARPHELPTELEPHONE property
            //InstallDate ==> The last time this product received service.
            //The value of this property is replaced each time a patch is applied or removed from
            //the product or the / v Command - Line Option is used to repair the product.
            //If the product has received no repairs or patches this property contains
            //the time this product was installed on this computer.
            //InstallLocation ==> ARPINSTALLLOCATION property
            //InstallSource ==> SourceDir property
            //URLInfoAbout ==> ARPURLINFOABOUT property
            //URLUpdateInfo ==> ARPURLUPDATEINFO property
            //AuthorizedCDFPrefix ==> ARPAUTHORIZEDCDFPREFIX property
            //Comments ==> Comments provided to the Add or Remove Programs control panel.
            //Contact ==> Contact provided to the Add or Remove Programs control panel.
            //EstimatedSize ==> Determined and set by the Windows Installer.
            //Language ==> ProductLanguage property
            //ModifyPath ==> Determined and set by the Windows Installer.
            //Readme ==> Readme provided to the Add or Remove Programs control panel.
            //UninstallString ==> Determined and set by Windows Installer.
            //SettingsIdentifier ==> MSIARPSETTINGSIDENTIFIER property 
            #endregion

            //string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string uninstallKeyWow6432Node = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

            var softwares = new List<Software>();
            int index = 1;


            #region MyRegion
            //// search in: CurrentUser
            //using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(uninstallKey))
            //{
            //    foreach (string skName in rk.GetSubKeyNames())
            //    {
            //        using (RegistryKey sk = rk.OpenSubKey(skName))
            //        {
            //            try
            //            {
            //                softwares.Add(new Software
            //                {
            //                    Id = index,
            //                    Name = sk.GetValue("DisplayName").ToString(),
            //                    Size = sk.GetValue("EstimatedSize").ToString() == null ? "0" : sk.GetValue("EstimatedSize").ToString()
            //                    //Publisher = sk.GetValue("Publisher").ToString(),
            //                    //InstallDate = sk.GetValue("InstallDate").ToString(),
            //                    //InstallLocation = sk.GetValue("InstallLocation").ToString()
            //                });
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Exception : " + ex.InnerException);
            //            }
            //        }
            //        index++;

            //    }

            //}
            //// search in: LocalMachine_32
            //using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            //{
            //    foreach (string skName in rk.GetSubKeyNames())
            //    {
            //        using (RegistryKey sk = rk.OpenSubKey(skName))
            //        {
            //            try
            //            {
            //                softwares.Add(new Software
            //                {
            //                    Id = index,
            //                    Name = sk.GetValue("DisplayName").ToString(),
            //                    Size = sk.GetValue("EstimatedSize").ToString() == null ? "0" : sk.GetValue("EstimatedSize").ToString()
            //                    //Publisher = sk.GetValue("Publisher").ToString(),
            //                    //InstallDate = sk.GetValue("InstallDate").ToString(),
            //                    //InstallLocation = sk.GetValue("InstallLocation").ToString()
            //                });
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Exception : " + ex.InnerException);
            //            }
            //        }
            //        index++;

            //    }
            //    //foreach (var item in softwares)
            //    //{
            //    //    Console.WriteLine(" " + item.Id + " Software  " + item.Name + " EstimatedSize  " + item.Size);
            //    //    //+ " Publisher  " + item.Publisher + " InstallDate  " + item.InstallDate);
            //    //}
            //    //Console.WriteLine(" Total  Softwares Installed  " + softwares.Count.ToString());
            //} 
            #endregion
            // search in: LocalMachine_64
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKeyWow6432Node))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            softwares.Add(new Software
                            {
                                Id = index,
                                Name = sk.GetValue("DisplayName").ToString()
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception : " + ex.InnerException);
                        }
                    }
                    index++;

                }

            }

            foreach (var item in softwares)
            {
                Console.WriteLine(" " + item.Id + " Software  " + item.Name + " EstimatedSize  " + item.Size);
                //+ " Publisher  " + item.Publisher + " InstallDate  " + item.InstallDate);
            }
            Console.WriteLine(" Total  Softwares Installed  " + softwares.Count.ToString());

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
        static async Task<List<Software>> GetSoftwares()
        {
            var softwares = new List<Software>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54741/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/user");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    softwares = await response.Content.ReadAsAsync<List<Software>>();
                }
            }

            return softwares;
        }
        private static void InstalledApps()
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
            return "MAC:"+ addr[0].ToString()+" |IP:"+addr[1].ToString();
        }
        public static bool IsApplictionInstalled(string p_name)
        {
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // NOT FOUND
            return false;
        }
    }
}

