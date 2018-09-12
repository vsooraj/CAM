using CAM.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CAM.Service.Data.Repository
{
    public class SoftwareRepository : ISoftwareRepository
    {
        public SoftwareRepository()
        {

        }
        public void Create(Software software)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=13.76.155.59;Initial Catalog=CAM; User ID=sa;Password=RootUser123456789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("insert into Softwares(Name,IP,Host,InstalledDate,Vendor,Version) values ('" + software.Name + "','" + software.SystemInfo.IP + "','"  + software.SystemInfo.Host + "','"+ software.InstallDate + "','" + software.Vendor + "','" + software.Version + "')", connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();


            }
        }

        public IEnumerable<Software> Read()
        {
            IEnumerable<Software> queryResult;
            using (SqlConnection connection = new SqlConnection("Data Source=13.76.155.59;Initial Catalog=CAM; User ID=sa;Password=RootUser123456789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                queryResult = connection.Query<Software>("SELECT Id, Name,IP,Host FROM Softwares");
            }
            return queryResult;

        }


    }
}

