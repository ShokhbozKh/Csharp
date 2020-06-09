using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Models.BudgetViewModels
{
    public class HistoryViewModel
    {
        public SelectList IncomeCategories { get; set; }
        public SelectList ExpenseCategories { get; set; }
        public SelectList Categories { get; set; }

        [Display(Name = "Choose Category")]
        public string CategoryName { get; set; }

        public string SearchString { get; set; }

        public string DisplayDate { get; set; }

        public IEnumerable<History> HistoriesList { get; set; }
    }
}
