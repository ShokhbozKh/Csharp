USE DeansOffice;

SELECT * FROM Student;
SELECT * FROM Course;
SELECT * FROM Enrollment;
SELECT * FROM Department;
SELECT * FROM Instructor;
SELECT * FROM CourseAssignment;
SELECT * FROM OfficeAssignment;

DELETE FROM Student;
DELETE FROM Course;
DELETE FROM Enrollment;

DBCC CHECKIDENT ('Student', RESEED, 0);
DBCC CHECKIDENT ('Course', RESEED, 0);
DBCC CHECKIDENT ('Enrollment', RESEED, 0);