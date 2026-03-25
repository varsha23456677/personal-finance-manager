//namespace PersonalFinanceAPI.Models
//{
//    public class User
//    {
//    }
//}
namespace PersonalFinanceAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties — EF Core uses these to understand relationships
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public ICollection<Saving> Savings { get; set; } = new List<Saving>();
    }
}