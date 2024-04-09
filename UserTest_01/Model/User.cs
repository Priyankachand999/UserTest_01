using System.Diagnostics.Metrics;

namespace UserTest_01.Model
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public List<TestResult> TestResults { get; set; }
        public TestCategory Category { get; set; }
        
        

    }
}
