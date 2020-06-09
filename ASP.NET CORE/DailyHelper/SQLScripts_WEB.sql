/*
DROP TABLE Budget.History;

GO ALTER TABLE Budget.Expense
DROP CONSTRAINT FK_Expense_History_ExpenseId;
GO
ALTER TABLE Budget.Income
DROP CONSTRAINT FK_Income_History_IncomeId;

ALTER TABLE Budget.Expense
DROP INDEX IX_Expense_ExpenseId;

ALTER TABLE Budget.Expense
DROP COLUMN ExpenseId;

DROP TABLE Budget.Income;
DROP TABLE Budget.Expense;
DROP TABLE Budget.History;

DROP TABLE Budget.Category;	
*/

----------------- DDL ---------------------

------------ Category ---------------
/*internationalization..... */

INSERT INTO Budget.Category VALUES ('Salary', 0), ('Freelance', 0), ('Rent for House', 0), ('Other Incomes', 0);
INSERT INTO Budget.Category VALUES ('Products', 1), ('Transport', 1), ('Mobile Connection', 1), ('Internet', 1), ('Games', 1), ('Education', 1), ('Others', 1);

SELECT * FROM Budget.Category;


------ Income -----

INSERT INTO Budget.Income VALUES ('Website', 500, 3, '2020-04-29'), ('Yunusabad', 300, 4, '2020-04-30'), ('Mirabad', 350, 4, '2020-04-30');

SELECT i.Description, i.TotalSum, i.AddedDate, c.Name as Category
FROM Budget.Income i, Budget.Category c
WHERE i.CategoryId = c.IdCategory;

UPDATE Budget.Income SET Description = 'Yunusabad' WHERE IdIncome = 10;
UPDATE Budget.Income SET Description = 'Mirobod' WHERE IdIncome = 11;

SELECT * FROM Budget.Income;

-------------- Expense ------------------------

INSERT INTO Budget.Expense VALUES ('Weekly', 50, 6, '2020-04-20'), ('Proezdnoj', 50, 7, '2020-04-01'), ('University Fee', 3000, 11, '2020-01-01'), ('Online Courses', 30, 11, '2020-03-15');

SELECT e.Description, e.TotalSum, e.AddedDate, c.Name as Category
FROM Budget.Expense e, Budget.Category c
WHERE e.CategoryId = c.IdCategory;

SELECT * FROM Budget.Expense;

---- History -----

INSERT INTO Budget.History VALUES ('2020-05-05', 'Weekly', 50, 6, 'Expense');

SELECT * FROM Budget.History;

DELETE FROM Budget.History WHERE IdHistory > 1;

--------------- Triggers ---------------

CREATE OR ALTER TRIGGER Budget.CheckCategoryType ON Budget.Income
    AFTER INSERT  
AS  
    IF (ROWCOUNT_BIG() = 0)
RETURN;
    IF EXISTS (SELECT *  
               FROM Budget.Category AS p   
               JOIN inserted AS i   
               ON p.IdCategory = i.CategoryId   
               WHERE p.CategoryType = 1
              )
BEGIN  
    RAISERROR ('Cannot insert Expense category type into Income item', 1, 1);  
    ROLLBACK TRANSACTION;  
    RETURN;
END;

CREATE TRIGGER Budget.CheckCategoryTypeExpense ON Budget.Expense
    AFTER INSERT  
AS  
    IF (ROWCOUNT_BIG() = 0)
RETURN;
IF EXISTS (SELECT *  
           FROM Budget.Category AS p   
           JOIN inserted AS i   
           ON p.IdCategory = i.CategoryId   
           WHERE p.CategoryType = 0
          )
BEGIN  
    RAISERROR ('Cannot insert Expense category type into Income item', 1, 1);  
    ROLLBACK TRANSACTION;  
    RETURN;
END;


CREATE TRIGGER Budget.DeletedIncomeToHistory
    ON Budget.Income
    FOR DELETE
AS
  BEGIN 
    INSERT INTO HISTORY(Description, TotalSum, CategoryId, DeletedDate, ItemType)
       SELECT 
           d.Description, d.TotalSum, d.CategoryId, GETDATE(), 'Income'
       FROM deleted d;

       PRINT 'Successfully inserted into history table';
  END
GO
/*
test
SELECT * FROM Budget.Income;
DELETE FROM Budget.Income WHERE IdIncome = 7;
SELECT * FROM Budget.Income;
SELECT * FROM Budget.History;
*/




CREATE TRIGGER Budget.DeletedExpenseToHistory
    ON Budget.Expense
    FOR DELETE
AS
  BEGIN 
    INSERT INTO HISTORY(Description, TotalSum, CategoryId, DeletedDate, ItemType)
       SELECT 
           d.Description, d.TotalSum, d.CategoryId, GETDATE(), 'Expense'
       FROM deleted d;

       PRINT 'Successfully inserted into history table';
  END
GO

/* test
SELECT * FROM Budget.Expense;
DELETE FROM Budget.Expense WHERE IdExpense = 4;
SELECT * FROM Budget.Expense;
*/


/* Test trigger 
INSERT INTO Budget.Income VALUES (
INSERT INTO Budget.Income VALUES ('Micros', 1500, 6, '2020-04-29')
SELECT * FROM Budget.Category;
SELECT * FROM Budget.History;
*/

SELECT * FROM Budget.Income;



---------- Procedures ---------------



CREATE PROCEDURE Budget.AddIncome  (@description   VARCHAR(150),
                                    @totalSum     DECIMAL(18,2),
                                    @categoryId   INT)
AS  
  BEGIN  
        BEGIN  
            IF (Budget.CheckItem(@description, @totalSum, @categoryId, 'Income') > 0)
                RAISERROR ('Already existing item', 1, 2);
            ELSE
                INSERT INTO Budget.Income  
                VALUES     ( @description, @totalSum, @categoryId, GETDATE())  
        END 

        PRINT ('New item was successfully added');
END

/* test
EXECUTE Budget.AddIncome 'Test', 50, 2;
SELECT * FROM Budget.Income;
GO
*/


CREATE PROCEDURE Budget.AddExpense  (@description   VARCHAR(150),
                                      @totalSum      DECIMAL(18,2),
                                      @categoryId    INT)
AS  
  BEGIN  
        BEGIN  
            IF (Budget.CheckItem(@description, @totalSum, @categoryId, 'Income') > 0)
                RAISERROR ('Already existing item', 1, 2);
            ELSE
                INSERT INTO Budget.Expense  
                VALUES     ( @description, @totalSum, @categoryId, GETDATE())  
        END 

        PRINT ('New item was successfully added');
END

/* test
EXECUTE Budget.AddExpense 'Test2', 50, 6;
SELECT * FROM Budget.Expense;
GO
*/


--------- Function ------------
/* Check if we want to add already existing data */

ALTER FUNCTION Budget.CheckItem (@description   VARCHAR(150),
                                  @totalSum      DECIMAL(18,2),
                                  @categoryId    INT,
                                  @itemType      VARCHAR(20))
RETURNS INT
WITH EXECUTE AS CALLER
AS
BEGIN
    DECLARE @countItem INT;

    -- Check if we want to count on Income or Expense table ----
    IF(@itemType='Income')
        SET @countItem = (SELECT COUNT(*)
                          FROM Budget.Income
                          WHERE Description = @description AND TotalSum = @totalSum
                                                    AND CategoryId = @categoryId);

    ELSE IF(@itemType='Expense')
        SET @countItem = (SELECT COUNT(*)
                          FROM Budget.Expense
                          WHERE Description = @description AND TotalSum = @totalSum
                                                    AND CategoryId = @categoryId);
    
    IF @countItem > 0
        RETURN @countItem;
    
    RETURN 0;
END;
GO

/*
SELECT * FROM Budget.Income;
SELECT Budget.CheckItem('Micros', 1500, 2, 'Income') AS 'Number of items';
SELECT Budget.CheckItem('Test', 50, 6, 'Income') AS 'Number of items in expense';

---Stupid Date!!! It should work actually... -----
SELECT * FROM Budget.Expense;
SELECT Budget.CheckItem('Test', 50, 6, 'Expense') AS 'Number of items in expense';
*/

select * from Budget.Category WHERE CategoryType = 1;