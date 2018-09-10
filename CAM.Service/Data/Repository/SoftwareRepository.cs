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
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CAM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand cmd = new SqlCommand("insert into Softwares(name,ip) values ('" + software.Name + "','" + software.IP + "')", connection);
                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();


            }
        }

        public IEnumerable<Software> Read()
        {
            IEnumerable<Software> queryResult;
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CAM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                queryResult = connection.Query<Software>("SELECT [Id], [name],[ip] FROM dbo.[Softwares]");
            }
            return queryResult;

        }


    }
}

