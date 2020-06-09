using System.Linq;
using System.Threading.Tasks;
using BudgetManagement.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.DAL
{
    public class SqlDbLayer : IDbLayer
    {
        public readonly BudgetDbContext _context;

        public SqlDbLayer(BudgetDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category newCategory)
        {
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return newCategory;
        }

        public async Task<Expense> AddExpense(Expense newExpense)
        {
            _context.Expenses.Add(newExpense);
            await _context.SaveChangesAsync();

            return newExpense;
        }

        public async Task<Income> AddIncome(Income newIncome)
        {
            _context.Incomes.Add(newIncome);
            await _context.SaveChangesAsync();

            return newIncome;
        }

        public async Task<Category> DeleteCategory(int? id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoryToDelete);
            await _context.SaveChangesAsync();

            _context.Remove(categoryToDelete);

            return null;
        }

        public async Task<Expense> DeleteExpense(int? id)
        {
            var expenseToDelete = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expenseToDelete);
            await _context.SaveChangesAsync();

            _context.Remove(expenseToDelete);

            return null;
        }

        public async Task<Income> DeleteIncome(int? id)
        {
            var incomeToDelete = await _context.Incomes.FindAsync(id);
            _context.Incomes.Remove(incomeToDelete);
            await _context.SaveChangesAsync();

            _context.Remove(incomeToDelete);

            return null;
        }

        public async Task<Category> EditCategory(Category categoryToEdit)
        {
            _context.Update(categoryToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Expense> EditExpense(Expense expenseToEdit)
        {
            _context.Update(expenseToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Income> EditIncome(Income incomeToEdit)
        {
            _context.Update(incomeToEdit);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Expense> GetExpense(int? id) => await _context.Expenses
                                                                .Include(s => s.Category)
                                                                .FirstAsync(e => e.IdExpense == id);

        public async Task<Income> GetIncome(int? id) => await _context.Incomes
                                                                .Include(s => s.Category)
                                                                .FirstAsync(e => e.IdIncome == id);

        public async Task<History> GetHistory(int? id) => await _context.Histories
                                                                .Include(s => s.Category)
                                                                .FirstAsync(e => e.IdHistory == id);


        public async Task<IEnumerable<Category>> GetCategories() => await _context.Categories
                                                                    .ToListAsync();
        

        public async Task<IEnumerable<Category>> GetExpenseCategories() => await _context.Categories
                                                                            .Where(s => s.CategoryType == Models.Type.Expense)
                                                                            .ToListAsync();

        public async Task<IEnumerable<Category>> GetIncomeCategories() => await _context.Categories
                                                                            .Where(s => s.CategoryType == Models.Type.Income)
                                                                            .ToListAsync();

        public async Task<IEnumerable<Expense>> GetExpenses() => await _context.Expenses
                                                                    .Include(s => s.Category)
                                                                    .ToListAsync();

        public async Task<IEnumerable<Income>> GetIncomes() => await _context.Incomes
                                                                .Include(s => s.Category)
                                                                .ToListAsync();

        public async Task<IEnumerable<History>> GetHistories() => await _context.Histories
                                                                    .Include(s => s.Category)
                                                                    .ToListAsync();
    }
}
