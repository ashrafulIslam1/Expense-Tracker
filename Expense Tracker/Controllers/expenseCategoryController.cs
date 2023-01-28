using Microsoft.AspNetCore.Mvc;
using Expense_Tracker.Services;
using Expense_Tracker.ViewModels;
using Expense_Tracker.Data;

namespace Expense_Tracker.Controllers
{
    public class expenseCategoryController : Controller
    {
        private ApplicationDbContext _dbContext;
        private expenseCategoryService _expenseCategoryService;
        public expenseCategoryController(expenseCategoryService expenseCategoryService, ApplicationDbContext dbContext)
        {
            _expenseCategoryService = expenseCategoryService;
            _dbContext = dbContext;
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

        // Here I am checking the duplicate entry to the category, unique category name validation
        public JsonResult IsCategoryNameExist(string checkName)
        {
            return Json(_dbContext.Categories.Any(x => x.categoryName == checkName));
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
