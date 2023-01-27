using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Services;
using Expense_Tracker.ViewModels;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(expenseCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _expenseCategoryService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            if (id == 0)
                return NotFound(id);

            var updateExpenseCategory = _expenseCategoryService.GetById(id);
            
            if (updateExpenseCategory == null)
                return NotFound(id);

            return View(updateExpenseCategory);
        }

        [HttpPost]
        public IActionResult Update(expenseCategoryViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _expenseCategoryService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound(id);
            }
            _expenseCategoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
