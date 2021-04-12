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
DELETE FROM Department;
DELETE FROM Instructor;
DELETE FROM CourseAssignment;
DELETE FROM OfficeAssignment;

DBCC CHECKIDENT ('Student', RESEED, 0);
DBCC CHECKIDENT ('Course', RESEED, 0);
DBCC CHECKIDENT ('Enrollment', RESEED, 0);
DBCC CHECKIDENT ('Department', RESEED, 0);
DBCC CHECKIDENT ('Instructor', RESEED, 0);
DBCC CHECKIDENT ('CourseAssignment', RESEED, 0);
DBCC CHECKIDENT ('OfficeAssignment', RESEED, 0);