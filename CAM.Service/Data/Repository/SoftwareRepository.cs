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
            using (SqlConnection connection = new SqlConnection("Data Source=CS-035-LT-WS\\SQLEXPRESS;Initial Catalog=CAM; User ID=sa;Password=c@b0t1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("insert into Softwares(name,ip) values ('" + software.Name + "','" + software.IP + "')", connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();


            }
        }

        public IEnumerable<Software> Read()
        {
            IEnumerable<Software> queryResult;
            using (SqlConnection connection = new SqlConnection("Data Source=CS-035-LT-WS\\SQLEXPRESS;Initial Catalog=CAM; User ID=sa;Password=c@b0t1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                queryResult = connection.Query<Software>("SELECT Id, name,ip FROM Softwares");
            }
            return queryResult;

        }


    }
}

