using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public int categoryId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
