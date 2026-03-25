//namespace PersonalFinanceAPI.Models
//{
//    public class Transaction
//    {
//    }
//}
namespace PersonalFinanceAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty; // "Income" or "Expense"
        public string? Description { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}