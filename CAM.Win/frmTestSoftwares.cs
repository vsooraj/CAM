using CAM.Entities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace CAM.Win
{
    public partial class frmTestSoftwares : Form
    {
        public frmTestSoftwares()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            ReadAndUpload();
        }
        private void Read()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("InstallLocation", typeof(string)));
            dt.Columns.Add(new DataColumn("Instal Date", typeof(string)));
            dt.Columns.Add(new DataColumn("InstallState", typeof(string)));
            dt.Columns.Add(new DataColumn("Vendor", typeof(string)));
            dt.Columns.Add(new DataColumn("Version", typeof(string)));
            dt.Columns.Add(new DataColumn("PackageName", typeof(string)));
            dt.Columns.Add(new DataColumn("InstallSource", typeof(string)));
            dt.Columns.Add(new DataColumn("Language", typeof(string)));
            dt.Columns.Add(new DataColumn("LocalPackage", typeof(string)));
            dt.Columns.Add(new DataColumn("PackageCache", typeof(string)));
            dt.Columns.Add(new DataColumn("PackageCode", typeof(string)));
            dt.Columns.Add(new DataColumn("HelpTelephone", typeof(string)));
            dt.Columns.Add(new DataColumn("AssignmentType", typeof(string)));
            dt.Columns.Add(new DataColumn("Caption", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("IdentifyingNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ProductID", typeof(string)));
            dt.Columns.Add(new DataColumn("RegOwner", typeof(string)));
            dt.Columns.Add(new DataColumn("RegCompany", typeof(string)));
            dt.Columns.Add(new DataColumn("SKUNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Transforms", typeof(string)));
            dt.Columns.Add(new DataColumn("URLInfoAbout", typeof(string)));
            dt.Columns.Add(new DataColumn("URLUpdateInfo", typeof(string)));
            dt.Columns.Add(new DataColumn("HelpLink", typeof(string)));
            dt.Columns.Add(new DataColumn("WordCount", typeof(string)));
            SelectQuery Sq = new SelectQuery("Win32_Product");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject MO in osDetailsCollection)
            {
                DataRow dr = dt.NewRow();

                dr["Name"] = MO["Name"]?.ToString() ?? "Nill";
                dr["AssignmentType"] = MO["AssignmentType"]?.ToString() ?? "Nill";
                dr["Caption"] = MO["Caption"];
                dr["Description"] = MO["Description"];
                dr["IdentifyingNumber"] = MO["IdentifyingNumber"];
                dr["InstallLocation"] = MO["InstallLocation"];
                var newDate = DateTime.ParseExact(MO["InstallDate"]?.ToString() ?? DateTime.MinValue.ToString("yyyyMMdd"), "yyyyMMdd", CultureInfo.InvariantCulture);
                dr["Instal Date"] = newDate;
                dr["InstallState"] = MO["InstallState"];
                dr["HelpLink"] = MO["HelpLink"];
                dr["HelpTelephone"] = MO["HelpTelephone"];
                dr["InstallSource"] = MO["InstallSource"];
                dr["Language"] = MO["Language"];
                dr["LocalPackage"] = MO["LocalPackage"];
                dr["PackageCache"] = MO["PackageCache"];
                dr["PackageCode"] = MO["PackageCode"];
                dr["PackageName"] = MO["PackageName"];
                dr["InstallState"] = MO["InstallState"];
                dr["ProductID"] = MO["ProductID"];
                dr["RegOwner"] = MO["RegOwner"];
                dr["RegCompany"] = MO["RegCompany"];
                dr["SKUNumber"] = MO["SKUNumber"];
                dr["Transforms"] = MO["Transforms"];
                dr["URLInfoAbout"] = MO["URLInfoAbout"];
                dr["URLUpdateInfo"] = MO["URLUpdateInfo"];
                dr["Vendor"] = MO["Vendor"];
                dr["WordCount"] = MO["WordCount"];
                dr["Version"] = MO["Version"];
                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "Name Asc";
            dgvSoftwares.DataSource = dt;
        }

        private void ReadAndUpload()
        {
            SystemInfo systemInfo = new SystemInfo() { Host = getSystemInfo()[0], IP = getSystemInfo()[1] };
            SelectQuery Sq = new SelectQuery("Win32_Product");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            foreach (ManagementObject MO in osDetailsCollection)
            {

                var software = new Software
                {
                    Id = 0,
                    Name = MO["Name"]?.ToString() ?? "Nill",
                    Size = "0.00",
                    Publisher = MO["RegOwner"]?.ToString() ?? "Nill",
                    InstalledDate = DateTime.ParseExact(MO["InstallDate"]?.ToString() ?? DateTime.MinValue.ToString("yyyyMMdd"), "yyyyMMdd", CultureInfo.InvariantCulture).ToString(),
                    InstallLocation = MO["InstallLocation"]?.ToString() ?? "Nill",
                    Version = MO["Version"]?.ToString() ?? "Nill",
                    CreatedOn = DateTime.ParseExact(DateTime.MinValue.ToString("yyyyMMdd"), "yyyyMMdd", CultureInfo.InvariantCulture).ToString(),
                    Vendor = MO["Version"]?.ToString() ?? "Nill",
                    SystemInfo = systemInfo
                };

            }

        }
        private Software Create(Software model)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Host"]);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsJsonAsync("/api/Softwares", model).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                Software data = JsonConvert.DeserializeObject<Software>(stringData);
                return data;
            }

        }

        public void UseWMI()
        {
            string query = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'";

            ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
            ManagementObjectCollection moCollection = moSearch.Get();

            foreach (ManagementObject mo in moCollection)
            {
                //Console.WriteLine("HostName = " + mo["DNSHostName"]);
                //Console.WriteLine("Description = " + mo["Description"]);


                string[] addresses = (string[])mo["IPAddress"];
                foreach (string ipaddress in addresses)
                {
                    Console.WriteLine("IPAddress = " + ipaddress);
                }

                string[] subnets = (string[])mo["IPSubnet"];
                foreach (string ipsubnet in subnets)
                {
                    Console.WriteLine("IPSubnet = " + ipsubnet);
                }


                string[] defaultgateways = (string[])mo["DefaultIPGateway"];
                foreach (string defaultipgateway in defaultgateways)
                {
                    Console.WriteLine("DefaultIPGateway = " + defaultipgateway);
                }
            }
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
