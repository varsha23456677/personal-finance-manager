//namespace PersonalFinanceAPI.Models
//{
//    public class Saving
//    {
//    }
//}
namespace PersonalFinanceAPI.Models
{
    public class Saving
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GoalName { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; } = 0;
        public DateTime? Deadline { get; set; }

        // Navigation property
        public User User { get; set; } = null!;
    }
}