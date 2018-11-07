using CAM.Data.Repository;
using CAM.Entities;
using CAM.Win.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace CAM.Win
{
    public partial class FrmSoftwares : Form
    {
        private IDBLogRepository _dBLogRepository;

        public FrmSoftwares(IDBLogRepository dBLogRepository)
        {
            InitializeComponent();
            DisplaySystemInfo();
            _dBLogRepository = dBLogRepository;
        }

        private void DisplaySystemInfo()
        {
            try
            {
                var systemService = new SystemService();
                var systemInfo = systemService.Retrieve();
                TxtHost.Text = systemInfo.Host;
                TxtIP.Text = systemInfo.IP;
            }
            catch (Exception ex)
            {
                _dBLogRepository.Create(ex.Message);
                throw;
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {

            try
            {
                var dt = new DataTable();
                var softwareService = new SoftwareService();
                dt = softwareService.ReadAll();
                dgvSoftwares.DataSource = dt;
            }
            catch (Exception ex)
            {
                _dBLogRepository.Create(ex.Message);
                throw;
            }
        }
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            var systemService = new SystemService();
            var systemInfo = systemService.Retrieve();

            ReadAndUpload(systemInfo);
        }

        private void ReadAndUpload(SystemInfo systemInfo)
        {
            try
            {
                var softwareService = new SoftwareService();
                var softwareList = softwareService.Read();

                foreach (var software in softwareList)
                {
                    softwareService.Create(software);
                }
            }
            catch (Exception ex)
            {
                _dBLogRepository.Create(ex.Message);
                throw;
            }
        }


    }
}
