using Microsoft.AspNetCore.Mvc;
using BudgetManagement.Controllers;
using Xunit;
using System;
using Moq;
using BudgetManagement.DAL;
using System.Collections;
using BudgetManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementWEB.Tests
{
    public class HomeControllerTests
    {
        /// <summary>
        /// Functionalities
        /// </summary>
        
        // Formatting date


        [Fact]
        public void FormatDateTest()
        {
            // Arrange
            string dateToFormat = "";
            
            // Act
            HomeController.FormatDate(ref dateToFormat, 2020, 2, 1);

            //Assert
            Assert.Equal("01.02.2020", dateToFormat);
        }

        [Fact]
        public void FormatDateTest1()
        {
            // Arrange
            string dateToFormat = "";
            
            // Act
            HomeController.FormatDate(ref dateToFormat, 0, 2, 1);

            //Assert
            Assert.Equal("01.02", dateToFormat);
        }

        [Fact]
        public void FormatDateTest2()
        {
            // Arrange
            string dateToFormat = "";

            // Act
            HomeController.FormatDate(ref dateToFormat, 0, 0, 8);

            //Assert
            Assert.Equal("08", dateToFormat);
        }

        [Fact]
        public void FormatDateTest3()
        {
            // Arrange
            string dateToFormat = "";

            // Act
            
            HomeController.FormatDate(ref dateToFormat, 0, 0, 12);

            //Assert
            Assert.Equal("12", dateToFormat);
        }

        [Fact]
        public void FormatDateTest4()
        {
            // Arrange
            string dateToFormat = "";

            // Act
            HomeController.FormatDate(ref dateToFormat, 0, 0, 0);

            //Assert
            Assert.Equal("ERROR_DATE", dateToFormat);
        }


        // Calculate total income, expense, budget

        [Fact]
        public void GetDisplayDateTest()
        {
            // Arrange
            string dateToDisplay = "";
            DateTime minDate = new DateTime(2019, 5, 2);
            DateTime maxDate = new DateTime(2020, 5, 2);

            // Act
            dateToDisplay = HomeController.GetDisplayDate(minDate, maxDate);

            // Assert
            Assert.Equal("02.05.2019-02.05.2020", dateToDisplay);
        }
        

        [Fact]
        public void GetDisplayDateTest1()
        {
            // Arrange
            string dateToDisplay = "";
            DateTime minDate = new DateTime(2020, 4, 2);
            DateTime maxDate = new DateTime(2020, 5, 2);

            // Act
            dateToDisplay = HomeController.GetDisplayDate(minDate, maxDate);

            // Assert
            Assert.Equal("02.04-02.05.2020", dateToDisplay);
        }

        [Fact]
        public void GetDisplayDateTest2()
        {
            // Arrange
            string dateToDisplay = "";
            DateTime minDate = new DateTime(2020, 5, 2);
            DateTime maxDate = new DateTime(2020, 5, 2);

            // Act
            dateToDisplay = HomeController.GetDisplayDate(minDate, maxDate);

            // Assert
            Assert.Equal("02-02.05.2020", dateToDisplay);
        }

        [Fact]
        public void GetDisplayDateTest3()
        {
            // Arrange
            string dateToDisplay = "";
            DateTime minDate = new DateTime(2019, 6, 3);
            DateTime maxDate = new DateTime(2020, 5, 2);

            // Act
            dateToDisplay = HomeController.GetDisplayDate(minDate, maxDate);

            // Assert
            Assert.Equal("03.06.2019-02.05.2020", dateToDisplay);
        }

        [Fact]
        public void GetDisplayDateTest4()
        {
            // Arrange
            string dateToDisplay = "";
            DateTime minDate = new DateTime(2020, 5, 3);
            DateTime maxDate = new DateTime(2020, 5, 2);

            // Act
            dateToDisplay = HomeController.GetDisplayDate(minDate, maxDate);

            // Assert
            Assert.Equal("ERROR_DATE", dateToDisplay);
        }

        /// <summary>
        /// Logic
        /// </summary>


        /*
        [Fact]
        public async Task Index_ReturnsViewResult_WithAListOfIncomesTest()
        {
            // Arrange
            var mockRepo = new Mock<IDbLayer>();
            mockRepo.Setup(repo => repo.GetExpenses())
                .ReturnsAsync(GetExpensesTest());

            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index("", "");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Income>>(viewResult.Model);
            Assert.Equal(6, model.Count());
        }

        private List<Expense> GetExpensesTest()
        {
            var incomes = new List<Expense>();

            incomes.Add(new Expense()
            {
                IdExpense = 1,
                AddedDate = new DateTime(2020, 4, 20),
                Description = "Weekly",
                TotalSum = 100,
                CategoryId = 2
            });
            incomes.Add(new Expense()
            {
                IdExpense = 2,
                AddedDate = new DateTime(2020, 4, 1),
                Description = "Description2",
                TotalSum = 100,
                CategoryId = 7
            });
            incomes.Add(new Expense()
            {
                IdExpense = 3,
                AddedDate = new DateTime(2020, 4, 23),
                Description = "Description3",
                TotalSum = 200,
                CategoryId = 3
            });
            incomes.Add(new Expense()
            {
                IdExpense = 7,
                AddedDate = new DateTime(2020, 4, 29),
                Description = "Description4",
                TotalSum = 130,
                CategoryId = 5
            });

            return incomes;
        }
        */
    }
}
