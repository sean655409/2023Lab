using CoreLab2023.Models;
using Dapper;
using System.Data.SqlClient;
using CoreLab2023.Models;
using CoreLab2023.Controllers;

namespace CoreLab2023.Repository
{
    public class TestTableRepository
    {
        string connStr { get; set; }
        public TestTableRepository() {
            var builder = WebApplication.CreateBuilder();
            connStr = builder.Configuration.GetValue<string>("sqlConnStr");
        }

        public List<TestTableModel> GetValue()
        {
          
            
            List<TestTableModel> result = new List<TestTableModel>();
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "select * from TestTable";
                var results = conn.Query<TestTableModel>(sql).ToList();
                result = results;

            }

            return result;
        }

        public void InsertItems(List<TestTableModel> updateItems)
        {
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "insert into TestTable (id, testType, testValue) values (@id, @testType, @testValue)";
    
                conn.Execute(sql, updateItems);
                string x = "1";
            }
        }

    }
}
