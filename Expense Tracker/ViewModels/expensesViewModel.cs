﻿using Expense_Tracker.Daterange_Attribute;

namespace Expense_Tracker.ViewModels
{
    public class expensesViewModel
    {
        public int Id { get; set; }
        public int categoryId { get; set; }
        public string? categoryName { get; set; }
        [CurrentDate(ErrorMessage = "Invalid date, please give current date.")]
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
