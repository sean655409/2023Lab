
namespace CoreLab2023.Models
{
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
