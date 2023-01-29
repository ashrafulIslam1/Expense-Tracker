using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.ViewModels
{
    public class expenseCategoryViewModel
    {
        public int categoryID { get; set; }
        [Remote("IsCategoryNameExist", "expenseCategory", ErrorMessage = "This category name is already available")]
        [Display(Name = "Category Name")]
        public string categoryName { get; set; }
    }
}
