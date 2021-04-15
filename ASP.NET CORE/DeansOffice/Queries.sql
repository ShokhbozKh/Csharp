USE DeansOffice;

DELETE FROM Student;
DELETE FROM Course;
DELETE FROM Department;
DELETE FROM Instructor;
DELETE FROM Enrollment;
DELETE FROM OfficeAssignment;
DELETE FROM CourseAssignment;

DBCC CHECKIDENT ('Student', RESEED, 0);
DBCC CHECKIDENT ('Course', RESEED, 0);
DBCC CHECKIDENT ('Department', RESEED, 0);
DBCC CHECKIDENT ('Instructor', RESEED, 0);
DBCC CHECKIDENT ('Enrollment', RESEED, 0);
DBCC CHECKIDENT ('OfficeAssignment', RESEED, 0);
DBCC CHECKIDENT ('CourseAssignment', RESEED, 0);

SELECT * FROM Student;
SELECT * FROM Course;
SELECT * FROM Department;
SELECT * FROM Instructor;
SELECT * FROM Enrollment;
SELECT * FROM OfficeAssignment;
SELECT * FROM CourseAssignment;