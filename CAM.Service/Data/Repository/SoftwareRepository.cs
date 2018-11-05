using CAM.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CAM.Service.Data.Repository
{
    public class SoftwareRepository : ISoftwareRepository
    {
        private IConfiguration _configuration;

        public SoftwareRepository()
        {
        }

        public SoftwareRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Create(Software software)
        {
            var conStr = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conStr))
            {

                SqlCommand cmd = new SqlCommand("insert into Softwares(Name,IP,Host,InstalledDate,Vendor,Version) values ('" + software.Name + "','" + software.SystemInfo.IP + "','" + software.SystemInfo.Host + "','" + DateTime.Now.ToShortDateString() + "','" + software.Vendor + "','" + software.Version + "')", connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();


            }
        }

        public IEnumerable<Software> Read()
        {
            IEnumerable<Software> queryResult;
            var conStr = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                queryResult = connection.Query<Software>("SELECT Id, Name,IP,Host,FORMAT ( InstalledDate, 'd', 'en-gb' ) as InstalledDate,Vendor,Version FROM Softwares");
            }
            return queryResult.ToList();

        }


    }
}

