namespace UserTest_01.Model
{
    public class TestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key to the User model
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime TestDate { get; set; }
        public TestCategory Category { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }
    }
}
