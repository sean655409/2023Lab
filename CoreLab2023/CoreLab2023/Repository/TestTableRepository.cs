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
        /// <summary>
        /// 取得連線字串
        /// </summary>
        public TestTableRepository() {
            var builder = WebApplication.CreateBuilder();
            connStr = builder.Configuration.GetValue<string>("sqlConnStr");
        }

        /// <summary>
        /// 取得全部項目
        /// </summary>
        /// <returns></returns>
        public List<TestTableModel> GetAllItems()
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
        /// <summary>
        /// 透過id，取得特定項目
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public TestTableModel GetItem(int _id)
        {
            TestTableModel result = new TestTableModel();
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "select * from TestTable where id=@id";
                var results = conn.Query<TestTableModel>(sql, new TestTableModel { id = _id }).ToList();
                if (results.Count == 0)
                {
                    return null;
                }
                result = results.First();
            }
            return result;
        }
        /// <summary>
        /// 新增項目
        /// </summary>
        /// <param name="insertItems"></param>
        public void InsertItems(List<TestTableModel> insertItems)
        {
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "insert into TestTable (id, testType, testValue) values (@id, @testType, @testValue)";

                conn.Execute(sql, insertItems);

            }
        }

        /// <summary>
        /// 新增項目
        /// </summary>
        /// <param name="insertItems"></param>
        public void InsertItem(TestTableModel insertItems)
        {
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "insert into TestTable (id, testType, testValue) values (@id, @testType, @testValue)";
    
                conn.Execute(sql, insertItems);
             
            }
        }
        /// <summary>
        /// 更新項目
        /// </summary>
        /// <param name="updateItems">更新內容</param>
        public void UpdateItem(TestTableModel updateItems)
        {
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "update TestTable set testType = @testType, testValue = @testValue where id=@id";

                conn.Execute(sql, updateItems);
           
            }
        }

        /// <summary>
        /// 刪除項目
        /// </summary>
        /// <param name="_id"></param>
        public void DeleteItem(int _id)
        {
            using (var conn = new SqlConnection(connStr))
            {
                var sql = "delete TestTable where id = @id";

                conn.Execute(sql, new { id = _id});
               
            }
        }

    }
}
