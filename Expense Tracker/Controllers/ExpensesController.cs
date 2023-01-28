using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Services;
using Expense_Tracker.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expense_Tracker.Controllers
{
    public class ExpensesController : Controller
    {
        private expensesService _expensesService;
        private expenseCategoryService _expenseCategoryService;
        public ExpensesController(expensesService expensesService, expenseCategoryService expenseCategoryService)
        {
            _expensesService = expensesService;
            _expenseCategoryService = expenseCategoryService;
        }

        public IActionResult Index(DateTime? fromDate, DateTime? toDate)
        {

            return View(_expensesService.GetAll(fromDate, toDate));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categorylist = new SelectList(_expenseCategoryService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Create(expensesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _expensesService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            if (id == 0)
                return NotFound(id);

            var updateExpenses = _expensesService.GetById(id);

            if (updateExpenses == null)
                return NotFound(id);

            ViewBag.categorylist = new SelectList(_expenseCategoryService.GetDropDown(), "Value", "Text");

            return View(updateExpenses);
        }

        [HttpPost]
        public IActionResult Update(expensesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _expensesService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound(id);
            }
            _expensesService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
