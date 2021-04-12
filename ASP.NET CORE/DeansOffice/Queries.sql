USE DeansOffice;

SELECT * FROM Student;
SELECT * FROM Course;
SELECT * FROM Enrollment;

DELETE FROM Student;

DBCC CHECKIDENT ('Student', RESEED, 0);