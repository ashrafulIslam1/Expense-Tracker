using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Services;

namespace Expense_Tracker.Controllers
{
    public class expenseCategoryController : Controller
    {
        private expenseCategoryService _expenseCategoryService;
        public expenseCategoryController(expenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }
        public IActionResult Index()
        {
            return View(_expenseCategoryService.GetAll());
        }
    }
}
