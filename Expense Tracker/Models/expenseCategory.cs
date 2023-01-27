using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class expenseCategory
    {
        [Key]
        public int categoryID { get; set; }
        public string categoryName { get; set; }

    }
}
