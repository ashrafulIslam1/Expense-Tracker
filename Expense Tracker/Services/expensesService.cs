using System;
using Expense_Tracker.Models;
using Expense_Tracker.ViewModels;
using Expense_Tracker.Data;

namespace Expense_Tracker.Services
{
    public class expensesService
    {
        private ApplicationDbContext _dbContext;
        public expensesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(expensesViewModel viewModel)
        {
            var model = new Expenses
            {
                categoryId = viewModel.categoryId,
                Date = viewModel.Date,
                Amount = viewModel.Amount,
            };
            _dbContext.Expenses.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(expensesViewModel viewModel)
        {
            var model = _dbContext.Expenses.Find(viewModel.Id);

            if (model == null)
                throw new Exception();

            model.Id = viewModel.Id;
            model.categoryId = viewModel.categoryId;
            model.Date = viewModel.Date;
            model.Amount = viewModel.Amount;
            
            _dbContext.Expenses.Update(model);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = _dbContext.Expenses.Find(id);

            if (null == model)
                throw new Exception();

            _dbContext.Expenses.Remove(model);
            _dbContext.SaveChanges();
        }

        public List<expensesViewModel> GetAll(DateTime? fromDate, DateTime? toDate)
        {
            var query = (from e in _dbContext.Expenses
                         join c in _dbContext.Categories on e.categoryId equals c.categoryID
                         select new expensesViewModel
                         {
                             Id = e.Id,
                             categoryName = c.categoryName,
                             Amount = e.Amount,
                             Date = e.Date,
                         }).AsQueryable();

            if(fromDate.HasValue && toDate == null)
            {
                query = query.Where(e => e.Date == fromDate.Value);
            }
            else if (fromDate.HasValue && toDate.HasValue)
            {
                query = query.Where(e => e.Date >= fromDate && e.Date <= toDate);
            }

            return query.ToList();
        }

        public expensesViewModel? GetById(int id)
        {
            var query = (from e in _dbContext.Expenses
                         where e.Id == id
                         select new expensesViewModel
                         {
                             Id = e.Id,
                             categoryId = e.categoryId,
                             Amount = e.Amount,
                             Date = e.Date,
                         }).SingleOrDefault();

            return query;
        }
    }
}
