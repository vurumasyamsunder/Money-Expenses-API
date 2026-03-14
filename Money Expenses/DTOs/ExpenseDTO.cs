 namespace Money_Expenses.DTOs
{
     public class incomeDTO
    {
        public int id { get; set; }
        public string source { get; set; }             // e.g., "Groceries", "Rent"
        public decimal amount { get; set; }
        public DateOnly income_date { get; set; }
        public string? Category { get; set; }          // e.g., "Food", "Utilities"
        public int? UserId { get; set; }
     }

    public class CreateIncomeDTO
    {
        public string source { get; set; }

        public decimal amount { get; set; }

        public DateTime income_date { get; set; }
    }
}
