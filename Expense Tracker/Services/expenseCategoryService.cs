using System;
using Expense_Tracker.Models;
using Expense_Tracker.ViewModels;
using Expense_Tracker.Data;

namespace Expense_Tracker.Services
{ 
    public class expenseCategoryService
    {
        private ApplicationDbContext _dbContext;
        public expenseCategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(expenseCategoryViewModel viewModel)
        {
            var model = new expenseCategory
            {
                categoryName = viewModel.categoryName,
            };
            _dbContext.Categories.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(expenseCategoryViewModel viewModel)
        {
            var model = _dbContext.Categories.Find(viewModel.categoryID);

            if (model == null)
                throw new Exception();

            model.categoryName = viewModel.categoryName;

            _dbContext.Categories.Update(model);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _dbContext.Categories.Find(id);

            if (null == model)
                throw new Exception();

            _dbContext.Categories.Remove(model);
            _dbContext.SaveChanges();
        }

        public List<expenseCategoryViewModel> GetAll()
        {
            var query = (from c in _dbContext.Categories
                        select new expenseCategoryViewModel
                        {
                            categoryID = c.categoryID,
                            categoryName = c.categoryName,
                        }).AsQueryable();

            return query.ToList();
        }

        public expenseCategoryViewModel? GetById(int id)
        {
            var query = (from c in _dbContext.Categories
                         where c.categoryID == id
                         select new expenseCategoryViewModel
                         {
                             categoryID = c.categoryID,
                             categoryName= c.categoryName,
                         }).SingleOrDefault();

            return query;
        }

        public List<dropDownViewModel> GetDropDown()
        {
            var query = (from c in _dbContext.Categories
                         select new dropDownViewModel
                         {
                             Value = c.categoryID,
                             Text = c.categoryName,
                         }).ToList();
            return query;
        }
    }
}
