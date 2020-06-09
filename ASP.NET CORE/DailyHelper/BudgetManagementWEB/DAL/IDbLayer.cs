using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetManagement.Models;

namespace BudgetManagement.DAL
{
    public interface IDbLayer
    {
        public Task<IEnumerable<Income>> GetIncomes();
        public Task<IEnumerable<Expense>> GetExpenses();
        public Task<IEnumerable<History>> GetHistories();
        public Task<IEnumerable<Category>> GetIncomeCategories();
        public Task<IEnumerable<Category>> GetExpenseCategories();
        public Task<IEnumerable<Category>> GetCategories();
        //public Task<IEnumerable<Item>> GetItems();

        // Category
        public Task<Category> AddCategory(Category newCategory);
        public Task<Category> EditCategory(Category categoryToEdit);
        public Task<Category> DeleteCategory(int? id);

        // Income

        public Task<Income> GetIncome(int? id);
        public Task<Income> AddIncome(Income newIncome);
        public Task<Income> EditIncome(Income incomeToEdit);
        public Task<Income> DeleteIncome(int? id);

        //Expense

        public Task<Expense> GetExpense(int? id);
        public Task<Expense> AddExpense(Expense newExpense);
        public Task<Expense> EditExpense(Expense expenseToEdit);
        public Task<Expense> DeleteExpense(int? id);

        // History
        public Task<History> GetHistory(int? id);
    }
}
