//namespace PersonalFinanceAPI.Models
//{
//    public class Category
//    {
//    }
//}
namespace PersonalFinanceAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // "Income" or "Expense"
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}