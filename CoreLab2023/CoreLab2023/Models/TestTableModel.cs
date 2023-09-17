
namespace CoreLab2023.Models
{
    /// <summary>
    /// 項目Model
    /// </summary>
    public class TestTableModel 
    {
        public int id { get; set; }
        public string testType { get; set; }
        public int testValue { get; set; }
   
    }

    public class TestTableModels
    {
        public List<TestTableModel> Models { get; set; }
    }
}
