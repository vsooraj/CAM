using System;
using System.Data;
using System.Globalization;
using System.Management;
using System.Windows.Forms;

namespace CAM.Win
{
    public partial class frmSoftwares : Form
    {
        SoftwareRepository softwareRepository = new SoftwareRepository();
        public frmSoftwares()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //dgvSoftwares.DataSource = softwareRepository.Read(SoftwareRepository.EnvironmentType.Developement);
            Read();
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
            dgvSoftwares.DataSource = dt;
        }

        private void dgvSoftwares_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}
