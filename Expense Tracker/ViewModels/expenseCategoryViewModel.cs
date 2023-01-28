using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Controllers;

namespace Expense_Tracker.ViewModels
{
    public class expenseCategoryViewModel
    {
        public int categoryID { get; set; }
        [Remote("IsCategoryNameExist", "expenseCategory", ErrorMessage = "This category name is already available")]
        public string categoryName { get; set; }
    }
}
